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
        public void SaveProgress_SetsCollectionWasSaved()
        {
            TestCollectible collectible = A.Collectible;
            collectible.SaveProgress();
            Assert.AreEqual(false, collectible.CollectionWasSaved);
            collectible.Collect();
            collectible.SaveProgress();
            Assert.AreEqual(true, collectible.CollectionWasSaved);
        }

        [Test]
        public void ResetProgress_EnablesCollider()
        {
            TestCollectible collectible = A.Collectible;
            collectible.Collect();
            collectible.SaveProgress();
            collectible.ResetProgress();
            Assert.AreEqual(false, collectible.WasCollected);
            Assert.AreEqual(true, collectible.Collider.enabled);
        }
    }
}
