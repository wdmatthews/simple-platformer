using UnityEngine;
using UnityEngine.UI;

namespace Project.UI
{
    [AddComponentMenu("Project/UI/Health Tracker Heart")]
    [DisallowMultipleComponent]
    public class HealthTrackerHeart : MonoBehaviour
    {
        [SerializeField] protected Image _fillImage = null;

        public void SetFill(float amount)
        {
            if (_fillImage) _fillImage.fillAmount = amount;
        }
    }
}
