using System.Collections;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using Project.Tests.Builders;
using Project.Tests.Collectibles;

namespace Project.Tests.PlayMode
{
    public class CollectibleTests
    {
        [Test]
        public void Collect_DisablesCollider()
        {
            TestCollectible collectible = A.Collectible;
            collectible.Collect();
            Assert.AreEqual(true, collectible.WasCollected);
            Assert.AreEqual(false, collectible.Collider.enabled);
        }
    }
}
