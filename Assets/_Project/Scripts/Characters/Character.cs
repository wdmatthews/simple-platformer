using UnityEngine;

namespace Project.Characters
{
    [AddComponentMenu("Project/Characters/Character")]
    [DisallowMultipleComponent]
    [RequireComponent(typeof(BoxCollider2D))]
    [RequireComponent(typeof(LayerChecker))]
    [RequireComponent(typeof(Rigidbody2D))]
    public class Character : MonoBehaviour
    {
        [SerializeField] protected CharacterSO _data = null;
        [SerializeField] protected Rigidbody2D _rigidbody = null;
        [SerializeField] protected LayerChecker _groundChecker = null;
        [SerializeField] protected LayerChecker _oneWayPlatformChecker = null;
        [SerializeField] protected BoxCollider2D _collider = null;
        [SerializeField] protected LayerChecker _ladderChecker = null;

        protected float _moveDirection = 0;
        protected bool _shouldJump = false;
        protected float _health = 0;
        protected bool _isDead = false;
        protected bool _isInvincible = false;
        protected float _invincibleTimer = 0;
        protected bool _shouldDrop = false;
        protected bool _isDropping = false;
        protected Collider2D _oneWayPlatform = null;
        protected bool _isClimbing = false;
        protected float _climbDirection = 0;

        protected void Awake()
        {
            if (!_rigidbody) _rigidbody = GetComponent<Rigidbody2D>();
            if (!_groundChecker) _groundChecker = GetComponent<LayerChecker>();
            if (!_oneWayPlatformChecker) _oneWayPlatformChecker = GetComponent<LayerChecker>();
            if (!_collider) _collider = GetComponent<BoxCollider2D>();
            if (!_ladderChecker) _ladderChecker = GetComponent<LayerChecker>();
        }

        protected void Start()
        {
            _rigidbody.gravityScale = _data.GravityScale;
            _health = _data.MaxHealth;
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
            }
            else
            {
                bool isGrounded = _groundChecker.IsTouching;
                bool isTouchingOneWayPlatform = _oneWayPlatformChecker.IsTouching;

                if (_shouldJump && isGrounded
                    && Mathf.Approximately(_rigidbody.velocity.y, 0)) Jump();
                if (_shouldDrop && isGrounded
                    && !_isDropping && isTouchingOneWayPlatform) StartDrop();
                else if (_isDropping && !isTouchingOneWayPlatform) StopDrop();
                if (!Mathf.Approximately(_climbDirection, 0)
                    && !_isClimbing && isTouchingLadder) StartClimb();
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
            if (_isInvincible) return;
            _health = Mathf.Clamp(_health - amount, 0, _data.MaxHealth);

            if (Mathf.Approximately(_health, 0)) Die();
            else MakeInvincibile();
        }

        public void Die()
        {
            _isDead = true;
        }

        public void Spawn(Transform spawnPoint)
        {
            _isDead = false;
            _health = _data.MaxHealth;
            transform.position = spawnPoint.position;
        }

        public void MakeInvincibile()
        {
            _isInvincible = true;
            _invincibleTimer = _data.InvincibleDuration;
        }

        public void RemoveInvincibility()
        {
            _isInvincible = false;
        }

        protected void StartDrop()
        {
            _isDropping = true;
            _oneWayPlatform = _oneWayPlatformChecker.TouchedCollider;
            Physics2D.IgnoreCollision(_collider, _oneWayPlatform);
        }

        protected void StopDrop()
        {
            _isDropping = false;
            Physics2D.IgnoreCollision(_collider, _oneWayPlatform, false);
            _oneWayPlatform = null;
        }

        protected void StartClimb()
        {
            _isClimbing = true;
            _rigidbody.gravityScale = 0;
            if (_isDropping) StopDrop();
        }

        protected void StopClimb()
        {
            _isClimbing = false;
            _rigidbody.gravityScale = _data.GravityScale;
        }
    }
}
