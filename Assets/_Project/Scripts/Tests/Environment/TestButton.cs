using UnityEngine;
using Project.Environment;

namespace Project.Tests.Environment
{
    public class TestButton : Button
    {
        public bool ResetOnTriggerExit { get => _resetOnTriggerExit; set => _resetOnTriggerExit = value; }
        public BoxCollider2D Collider => _collider;

        public bool WasPressed => _wasPressed;
        public bool WasPressedWhenSaved => _wasPressedWhenSaved;
    }
}
