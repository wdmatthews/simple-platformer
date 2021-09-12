using UnityEngine;
using Project.Collectibles;

namespace Project.Tests.Collectibles
{
    public class TestCollectible : Collectible
    {
        public CircleCollider2D Collider => _collider;

        public bool WasCollected => _wasCollected;
    }
}
