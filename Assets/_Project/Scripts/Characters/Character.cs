using UnityEngine;
using Project.Audio;
using Project.Events;

namespace Project.Characters
{
    [AddComponentMenu("Project/Characters/Character")]
    [DisallowMultipleComponent]
    [RequireComponent(typeof(BoxCollider2D))]
    [RequireComponent(typeof(LayerChecker))]
    [RequireComponent(typeof(Rigidbody2D))]
    [RequireComponent(typeof(CharacterAnimator))]
    public class Character : MonoBehaviour
    {
        [SerializeField] protected CharacterSO _data = null;
        [SerializeField] protected Rigidbody2D _rigidbody = null;
        [SerializeField] protected LayerChecker _groundChecker = null;
        [SerializeField] protected LayerChecker _oneWayPlatformChecker = null;
        [SerializeField] protected BoxCollider2D _collider = null;
        [SerializeField] protected LayerChecker _ladderChecker = null;
        [SerializeField] protected CharacterAnimator _animator = null;
        [SerializeField] protected FloatEventChannelSO _onCharacterHealthChangedChannel = null;
        [SerializeField] protected EventChannelSO _onCharacterDiedChannel = null;
        [SerializeField] protected EventChannelSO _onPausedChannel = null;
        [SerializeField] protected EventChannelSO _onResumedChannel = null;
        [SerializeField] protected AudioClip _damageClip = null;
        [SerializeField] protected AudioClip _deathClip = null;
        [SerializeField] protected AudioManagerSO _audioManager = null;

        protected float _moveDirection = 0;
        protected bool _shouldJump = false;
        protected float _health = 0;
        protected bool _isDead = false;
        public bool IsDead => _isDead;
        protected bool _isInvincible = false;
        protected float _invincibleTimer = 0;
        protected bool _shouldDrop = false;
        protected bool _isDropping = false;
        protected Collider2D _oneWayPlatform = null;
        protected bool _isClimbing = false;
        protected float _climbDirection = 0;
        protected Vector2 _velocityBeforePause = new Vector2();

        protected virtual void Awake()
        {
            if (!_rigidbody) _rigidbody = GetComponent<Rigidbody2D>();
            if (!_groundChecker) _groundChecker = GetComponent<LayerChecker>();
            if (!_oneWayPlatformChecker) _oneWayPlatformChecker = GetComponent<LayerChecker>();
            if (!_collider) _collider = GetComponent<BoxCollider2D>();
            if (!_ladderChecker) _ladderChecker = GetComponent<LayerChecker>();
            if (!_animator) _animator = GetComponent<CharacterAnimator>();
            if (_onPausedChannel) _onPausedChannel.OnRaised += Pause;
            if (_onResumedChannel) _onResumedChannel.OnRaised += Resume;
        }

        protected void Start()
        {
            _rigidbody.gravityScale = _data.GravityScale;
            _health = _data.MaxHealth;
            if (_onCharacterHealthChangedChannel) _onCharacterHealthChangedChannel.Raise(_health);
        }

        protected void OnDestroy()
        {
            if (_onPausedChannel) _onPausedChannel.OnRaised -= Pause;
            if (_onResumedChannel) _onResumedChannel.OnRaised -= Resume;
        }

        protected void Update()
        {
            if (_isInvincible)
            {
                if (Mathf.Approximately(_invincibleTimer, 0)) RemoveInvincibility();
                else _invincibleTimer = Mathf.Clamp(_invincibleTimer - Time.deltaTime, 0, _data.InvincibleDuration);
            }
        }

        protected void FixedUpdate()
        {
            _rigidbody.velocity = new Vector2(
                _moveDirection * _data.MoveSpeed,
                _rigidbody.velocity.y
            );

            bool isTouchingLadder = _ladderChecker.IsTouching;
            
            if (_isClimbing)
            {
                if (isTouchingLadder)
                {
                    _rigidbody.velocity = new Vector2(
                        _rigidbody.velocity.x,
                        _climbDirection * _data.MoveSpeed
                    );
                }
                else StopClimb();

                _animator.SetIsStill(
                    Mathf.Approximately(_rigidbody.velocity.x, 0)
                    && Mathf.Approximately(_rigidbody.velocity.y, 0)
                );
            }
            else
            {
                bool isGrounded = _groundChecker.IsTouching;
                bool isTouchingOneWayPlatform = _oneWayPlatformChecker.IsTouching;
                bool yVelocityIsZero = Mathf.Abs(_rigidbody.velocity.y) < 0.0001f;

                if (_shouldJump && isGrounded && yVelocityIsZero) Jump();
                if (_shouldDrop && isGrounded
                    && !_isDropping && isTouchingOneWayPlatform) StartDrop();
                else if (_isDropping && !isTouchingOneWayPlatform) StopDrop();
                if (!Mathf.Approximately(_climbDirection, 0)
                    && !_isClimbing && isTouchingLadder) StartClimb();

                _animator.SetIsGrounded(isGrounded && yVelocityIsZero);
            }
        }

        public void Move(float direction)
        {
            bool shouldFlip = !Mathf.Approximately(direction, 0)
                && !Mathf.Approximately(direction, _moveDirection)
                && (direction > 0 && Mathf.Approximately(transform.eulerAngles.y, 180)
                    || direction < 0 && Mathf.Approximately(transform.eulerAngles.y, 0));

            if (shouldFlip)
            {
                Vector3 eulerAngles = transform.eulerAngles;
                eulerAngles.y = 180 - eulerAngles.y;
                transform.eulerAngles = eulerAngles;
            }

            _moveDirection = direction;
            _animator.SetIsMoving(!Mathf.Approximately(_moveDirection, 0));
        }

        public void Jump()
        {
            _rigidbody.velocity = new Vector2(
                _rigidbody.velocity.x,
                _data.JumpSpeed
            );
        }

        public void Climb(float direction)
        {
            _climbDirection = direction;
        }

        public void TakeDamage(float amount)
        {
            if (_isInvincible || _isDead) return;
            _health = Mathf.Clamp(_health - amount, 0, _data.MaxHealth);
            if (_onCharacterHealthChangedChannel) _onCharacterHealthChangedChannel.Raise(_health);

            if (Mathf.Approximately(_health, 0)) Die();
            else
            {
                MakeInvincibile();
                if (_audioManager) _audioManager.PlaySFX(_damageClip);
            }
        }

        public void Die()
        {
            _isDead = true;
            if (_onCharacterDiedChannel) _onCharacterDiedChannel.Raise();
            if (_audioManager) _audioManager.PlaySFX(_deathClip);
        }

        public void Spawn(Transform spawnPoint)
        {
            _isDead = false;
            _health = _data.MaxHealth;
            transform.position = spawnPoint.position;
            _rigidbody.velocity = new Vector2();
            if (_onCharacterHealthChangedChannel) _onCharacterHealthChangedChannel.Raise(_health);
            RemoveInvincibility();
        }

        public void MakeInvincibile()
        {
            _isInvincible = true;
            _invincibleTimer = _data.InvincibleDuration;
            _animator.SetIsInvincible(_isInvincible);
        }

        public void RemoveInvincibility()
        {
            _isInvincible = false;
            _animator.SetIsInvincible(_isInvincible);
        }

        protected void StartDrop()
        {
            _isDropping = true;
            _oneWayPlatform = _oneWayPlatformChecker.TouchedCollider;
            Physics2D.IgnoreCollision(_collider, _oneWayPlatform);
            _animator.SetIsDropping(true);
        }

        protected void StopDrop()
        {
            _isDropping = false;
            Physics2D.IgnoreCollision(_collider, _oneWayPlatform, false);
            _oneWayPlatform = null;
            _animator.SetIsDropping(false);
        }

        protected void StartClimb()
        {
            _isClimbing = true;
            _rigidbody.gravityScale = 0;
            if (_isDropping) StopDrop();
            _animator.SetIsClimbing(true);
        }

        protected void StopClimb()
        {
            _isClimbing = false;
            _rigidbody.gravityScale = _data.GravityScale;
            _animator.SetIsClimbing(false);
        }

        public virtual void Pause()
        {
            _velocityBeforePause = _rigidbody.velocity;
            _rigidbody.velocity = new Vector2();
            _rigidbody.gravityScale = 0;
            _collider.enabled = false;
            enabled = false;
            _animator.Pause();
        }

        public virtual void Resume()
        {
            _rigidbody.velocity = _velocityBeforePause;
            _rigidbody.gravityScale = _data.GravityScale;
            _collider.enabled = true;
            enabled = true;
            _animator.Resume();
        }
    }
}
