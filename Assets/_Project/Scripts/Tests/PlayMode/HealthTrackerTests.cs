using System.Collections.Generic;
using NUnit.Framework;
using Project.Tests.Builders;
using Project.Tests.UI;

namespace Project.Tests.PlayMode
{
    public class HealthTrackerTests
    {
        [Test]
        public void Initialize_CreatesHearts()
        {
            TestHealthTracker tracker = A.HealthTracker;
            tracker.Initialize(3);
            Assert.AreEqual(3, tracker.Hearts.Count);
            Assert.AreEqual(3, tracker.HeartCount);
        }

        [Test]
        public void SetHealth_Full_FillsAllHearts()
        {
            TestHealthTracker tracker = A.HealthTracker;
            tracker.Initialize(3);
            tracker.SetHealth(3);
            List<TestHealthTrackerHeart> hearts = tracker.Hearts;
            Assert.AreEqual(1, hearts[0].FillAmount);
            Assert.AreEqual(1, hearts[1].FillAmount);
            Assert.AreEqual(1, hearts[2].FillAmount);
        }

        [Test]
        public void SetHealth_Zero_EmptiesAllHearts()
        {
            TestHealthTracker tracker = A.HealthTracker;
            tracker.Initialize(3);
            tracker.SetHealth(0);
            List<TestHealthTrackerHeart> hearts = tracker.Hearts;
            Assert.AreEqual(0, hearts[0].FillAmount);
            Assert.AreEqual(0, hearts[1].FillAmount);
            Assert.AreEqual(0, hearts[2].FillAmount);
        }

        [Test]
        public void SetHealth_Half_FillsHalfOfAllHearts()
        {
            TestHealthTracker tracker = A.HealthTracker;
            tracker.Initialize(3);
            tracker.SetHealth(1.5f);
            List<TestHealthTrackerHeart> hearts = tracker.Hearts;
            Assert.AreEqual(1, hearts[0].FillAmount);
            Assert.AreEqual(0.5f, hearts[1].FillAmount);
            Assert.AreEqual(0, hearts[2].FillAmount);
        }
    }
}
