using UnityEngine;

namespace Project.Characters
{
    [AddComponentMenu("Project/Characters/Character Animator")]
    [DisallowMultipleComponent]
    [RequireComponent(typeof(Animator))]
    [RequireComponent(typeof(SpriteRenderer))]
    public class CharacterAnimator : MonoBehaviour
    {
        private static readonly int _isMovingParameter = Animator.StringToHash("Is Moving");
        private static readonly int _isGroundedParameter = Animator.StringToHash("Is Grounded");
        private static readonly int _isDroppingParameter = Animator.StringToHash("Is Dropping");
        private static readonly int _isClimbingParameter = Animator.StringToHash("Is Climbing");
        private static readonly int _climbingSpeedParameter = Animator.StringToHash("Climbing Speed");
        private static readonly int _victoryParameter = Animator.StringToHash("Victory");

        [SerializeField] private float _invicibleAlpha = 0.75f;
        [SerializeField] private Animator _animator = null;
        [SerializeField] private SpriteRenderer _renderer = null;

        private void Awake()
        {
            if (!_animator) _animator = GetComponent<Animator>();
            if (!_renderer) _renderer = GetComponent<SpriteRenderer>();
        }

        private void Start()
        {
            SetIsMoving(false);
            SetIsGrounded(true);
            SetIsDropping(false);
            SetIsClimbing(false);
            SetIsStill(true);
        }

        public void SetIsMoving(bool value) => _animator.SetBool(_isMovingParameter, value);
        public void SetIsGrounded(bool value) => _animator.SetBool(_isGroundedParameter, value);
        public void SetIsDropping(bool value) => _animator.SetBool(_isDroppingParameter, value);
        public void SetIsClimbing(bool value) => _animator.SetBool(_isClimbingParameter, value);
        public void SetIsStill(bool value) => _animator.SetFloat(_climbingSpeedParameter, value ? 0 : 1);

        public void SetIsInvincible(bool value)
        {
            Color color = _renderer.color;
            color.a = value ? _invicibleAlpha : 1;
            _renderer.color = color;
        }

        public void TriggerVictory()
        {
            _animator.ResetTrigger(_victoryParameter);
            _animator.SetTrigger(_victoryParameter);
        }

        public void Pause()
        {
            _animator.enabled = false;
        }

        public void Resume()
        {
            _animator.enabled = true;
        }
    }
}
