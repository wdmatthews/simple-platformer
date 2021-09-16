using UnityEngine;
using Project.Tests.UI;

namespace Project.Tests.Builders
{
    public class CollectibleTrackerBuilder
    {
        public TestCollectibleTracker Build()
        {
            GameObject gameObject = new GameObject();
            TestCollectibleTracker tracker = gameObject.AddComponent<TestCollectibleTracker>();
            return tracker;
        }

        public static implicit operator TestCollectibleTracker(CollectibleTrackerBuilder builder) => builder.Build();
    }
}
