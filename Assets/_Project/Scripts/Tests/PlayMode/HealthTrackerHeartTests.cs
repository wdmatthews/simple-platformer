using NUnit.Framework;
using Project.Tests.Builders;
using Project.Tests.UI;

namespace Project.Tests.PlayMode
{
    public class HealthTrackerHeartTests
    {
        [Test]
        public void SetFill_SetsImageFill()
        {
            TestHealthTrackerHeart heart = A.HealthTrackerHeart;
            heart.SetFill(0.5f);
            Assert.AreEqual(0.5f, heart.FillImage.fillAmount);
            Assert.AreEqual(0.5f, heart.FillAmount);
        }
    }
}
