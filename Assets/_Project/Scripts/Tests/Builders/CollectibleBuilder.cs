using UnityEngine;
using Project.Tests.Collectibles;

namespace Project.Tests.Builders
{
    public class CollectibleBuilder
    {
        public TestCollectible Build()
        {
            GameObject gameObject = new GameObject();
            TestCollectible collectible = gameObject.AddComponent<TestCollectible>();
            return collectible;
        }

        public static implicit operator TestCollectible(CollectibleBuilder builder) => builder.Build();
    }
}
