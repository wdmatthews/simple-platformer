using UnityEngine;
using UnityEngine.InputSystem;

namespace Project.Characters
{
    [AddComponentMenu("Project/Characters/Player")]
    [DisallowMultipleComponent]
    [RequireComponent(typeof(Rigidbody2D))]
    [RequireComponent(typeof(PlayerInput))]
    public class Player : Character
    {
        public void Move(InputAction.CallbackContext context)
        {
            Move(context.ReadValue<float>());
        }
    }
}
