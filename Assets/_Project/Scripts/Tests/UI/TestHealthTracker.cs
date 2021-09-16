using System.Collections.Generic;
using Project.UI;

namespace Project.Tests.UI
{
    public class TestHealthTracker : HealthTracker
    {
        public TestHealthTrackerHeart HeartPrefab { set => _heartPrefab = value; }

        public List<TestHealthTrackerHeart> Hearts
        {
            get
            {
                List<TestHealthTrackerHeart> hearts = new List<TestHealthTrackerHeart>();

                for (int i = 0; i < _heartCount; i++)
                {
                    hearts.Add((TestHealthTrackerHeart)_hearts[i]);
                }

                return hearts;
            }
        }

        public int HeartCount => _heartCount;
    }
}
