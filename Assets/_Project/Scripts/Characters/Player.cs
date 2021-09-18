using UnityEngine;
using UnityEngine.InputSystem;

namespace Project.Characters
{
    [AddComponentMenu("Project/Characters/Player")]
    [DisallowMultipleComponent]
    [RequireComponent(typeof(PlayerInput))]
    public class Player : Character
    {
        [SerializeField] protected PlayerInput _input = null;

        protected override void Awake()
        {
            base.Awake();
            if (!_input) _input = GetComponent<PlayerInput>();
        }

        public void Move(InputAction.CallbackContext context)
        {
            Move(context.ReadValue<float>());
        }

        public void Jump(InputAction.CallbackContext context)
        {
            _shouldJump = Mathf.Approximately(context.ReadValue<float>(), 1);
        }

        public void Drop(InputAction.CallbackContext context)
        {
            _shouldDrop = Mathf.Approximately(context.ReadValue<float>(), 1);
        }

        public void Climb(InputAction.CallbackContext context)
        {
            Climb(context.ReadValue<float>());
        }

        public override void Pause()
        {
            base.Pause();
            _input.DeactivateInput();
        }

        public override void Resume()
        {
            base.Resume();
            _input.ActivateInput();
        }
    }
}
