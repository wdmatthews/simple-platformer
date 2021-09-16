using UnityEngine.UI;
using Project.UI;

namespace Project.Tests.UI
{
    public class TestHealthTrackerHeart : HealthTrackerHeart
    {
        public Image FillImage { get => _fillImage; set => _fillImage = value; }

        public float FillAmount => _fillImage.fillAmount;
    }
}
