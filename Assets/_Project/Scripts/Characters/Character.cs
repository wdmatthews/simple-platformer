using UnityEngine;

namespace Project.Characters
{
    [AddComponentMenu("Project/Characters/Character")]
    [DisallowMultipleComponent]
    [RequireComponent(typeof(GroundChecker))]
    [RequireComponent(typeof(Rigidbody2D))]
    public class Character : MonoBehaviour
    {
        [SerializeField] protected CharacterSO _data = null;
        [SerializeField] protected Rigidbody2D _rigidbody = null;
        [SerializeField] protected GroundChecker _groundChecker = null;
        [SerializeField] protected CharacterFloatEventChannelSO _damageCharacterChannel = null;

        protected float _moveDirection = 0;
        protected bool _shouldJump = false;
        protected float _health = 0;
        protected bool _isDead = false;

        protected void Awake()
        {
            if (!_rigidbody) _rigidbody = GetComponent<Rigidbody2D>();
            if (!_groundChecker) _groundChecker = GetComponent<GroundChecker>();
        }

        protected void Start()
        {
            _rigidbody.gravityScale = _data.GravityScale;
            _health = _data.MaxHealth;
        }

        protected void OnEnable()
        {
            _damageCharacterChannel.OnRaise += OnDamageCharacter;
        }

        protected void OnDisable()
        {
            _damageCharacterChannel.OnRaise -= OnDamageCharacter;
        }

        protected void FixedUpdate()
        {
            _rigidbody.velocity = new Vector2(
                _moveDirection * _data.MoveSpeed,
                _rigidbody.velocity.y
            );

            if (_shouldJump && _groundChecker.IsGrounded) Jump();
        }

        public void Move(float direction)
        {
            bool shouldFlip = !Mathf.Approximately(direction, 0)
                && !Mathf.Approximately(direction, _moveDirection)
                && (direction > 0 && _moveDirection < 0 || direction < 0);

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

        public void TakeDamage(float amount)
        {
            _health = Mathf.Clamp(_health - amount, 0, _data.MaxHealth);
            if (Mathf.Approximately(_health, 0)) Die();
        }

        public void Die()
        {
            _isDead = true;
        }

        protected void OnDamageCharacter(Character character, float amount)
        {
            if (character != this) return;
            TakeDamage(amount);
        }
    }
}
