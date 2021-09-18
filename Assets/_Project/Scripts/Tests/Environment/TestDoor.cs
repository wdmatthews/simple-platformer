using UnityEngine;
using Project.Environment;

namespace Project.Tests.Environment
{
    public class TestDoor : Door
    {
        public BoxCollider2D Collider => _collider;

        public bool WasUnlocked => _wasUnlocked;
        public bool WasUnlockedWhenSaved => _wasUnlocked;
        public bool WasEntered => _wasEntered;
    }
}
