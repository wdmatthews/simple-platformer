using UnityEngine;
using Project.Tests.UI;

namespace Project.Tests.Builders
{
    public class HealthTrackerBuilder
    {
        public TestHealthTracker Build()
        {
            GameObject gameObject = new GameObject();
            TestHealthTracker healthTracker = gameObject.AddComponent<TestHealthTracker>();
            healthTracker.HeartPrefab = A.HealthTrackerHeart;
            return healthTracker;
        }

        public static implicit operator TestHealthTracker(HealthTrackerBuilder builder) => builder.Build();
    }
}
