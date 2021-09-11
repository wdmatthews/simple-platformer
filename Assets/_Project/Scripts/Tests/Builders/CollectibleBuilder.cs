using UnityEngine;
using Project.Collectibles;
using Project.Tests.Collectibles;

namespace Project.Tests.Builders
{
    public class CollectibleBuilder
    {
        private static CollectibleSO _defaultData = null;

        public static CollectibleSO DefaultData
        {
            get
            {
                if (!_defaultData)
                {
                    _defaultData = ScriptableObject.CreateInstance<CollectibleSO>();
                }

                return _defaultData;
            }
        }

        private CollectibleSO _data = null;

        public CollectibleBuilder WithData(CollectibleSO data)
        {
            _data = data;
            return this;
        }

        public TestCollectible Build()
        {
            GameObject gameObject = new GameObject();
            TestCollectible collectible = gameObject.AddComponent<TestCollectible>();
            collectible.Data = _data ? _data : DefaultData;
            return collectible;
        }

        public static implicit operator TestCollectible(CollectibleBuilder builder) => builder.Build();
    }
}
