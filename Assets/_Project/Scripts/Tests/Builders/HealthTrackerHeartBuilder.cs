using UnityEngine;
using UnityEngine.UI;
using Project.Tests.UI;

namespace Project.Tests.Builders
{
    public class HealthTrackerHeartBuilder
    {
        public TestHealthTrackerHeart Build()
        {
            GameObject gameObject = new GameObject();
            TestHealthTrackerHeart healthTrackerHeart = gameObject.AddComponent<TestHealthTrackerHeart>();
            healthTrackerHeart.FillImage = gameObject.AddComponent<Image>();
            return healthTrackerHeart;
        }

        public static implicit operator TestHealthTrackerHeart(HealthTrackerHeartBuilder builder) => builder.Build();
    }
}
