using NUnit.Framework;
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

        [Test]
        public void SaveState_SetsCollectionWasSaved()
        {
            TestCollectible collectible = A.Collectible;
            collectible.SaveState();
            Assert.AreEqual(false, collectible.CollectionWasSaved);
            collectible.Collect();
            collectible.SaveState();
            Assert.AreEqual(true, collectible.CollectionWasSaved);
        }

        [Test]
        public void ResetState_EnablesCollider()
        {
            TestCollectible collectible = A.Collectible;
            collectible.Collect();
            collectible.SaveState();
            collectible.ResetState();
            Assert.AreEqual(false, collectible.WasCollected);
            Assert.AreEqual(true, collectible.Collider.enabled);
        }
    }
}
