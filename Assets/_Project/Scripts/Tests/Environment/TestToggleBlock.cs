using UnityEngine;
using Project.Environment;

namespace Project.Tests.Environment
{
    public class TestToggleBlock : ToggleBlock
    {
        public BoxCollider2D Collider => _collider;

        public bool IsOn => _isOn;
        public bool WasOnWhenSaved => _wasOnWhenSaved;
    }
}
