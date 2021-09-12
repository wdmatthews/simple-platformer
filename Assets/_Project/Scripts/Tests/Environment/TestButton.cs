using UnityEngine;
using Project.Environment;

namespace Project.Tests.Environment
{
    public class TestButton : Button
    {
        public BoxCollider2D Collider => _collider;

        public bool WasPressed => _wasPressed;
    }
}
