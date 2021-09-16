using UnityEngine;
using Project.Tests.UI;

namespace Project.Tests.Builders
{
    public class KeyTrackerBuilder
    {
        public TestKeyTracker Build()
        {
            GameObject gameObject = new GameObject();
            TestKeyTracker keyTracker = gameObject.AddComponent<TestKeyTracker>();
            return keyTracker;
        }

        public static implicit operator TestKeyTracker(KeyTrackerBuilder builder) => builder.Build();
    }
}
