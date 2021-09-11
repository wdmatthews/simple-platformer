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

        protected float _moveDirection = 0;
        protected bool _shouldJump = false;

        protected void Awake()
        {
            if (!_rigidbody) _rigidbody = GetComponent<Rigidbody2D>();
            if (!_groundChecker) _groundChecker = GetComponent<GroundChecker>();
        }

        protected void Start()
        {
            _rigidbody.gravityScale = _data.GravityScale;
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
    }
}
