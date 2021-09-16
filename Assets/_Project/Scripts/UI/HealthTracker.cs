using System.Collections.Generic;
using UnityEngine;
using Project.Events;

namespace Project.UI
{
    [AddComponentMenu("Project/UI/Health Tracker")]
    [DisallowMultipleComponent]
    public class HealthTracker : MonoBehaviour
    {
        [SerializeField] protected HealthTrackerHeart _heartPrefab = null;
        [SerializeField] protected FloatEventChannelSO _onCharacterHealthChangedChannel = null;

        protected List<HealthTrackerHeart> _hearts = new List<HealthTrackerHeart>();
        protected int _heartCount = 0;

        protected void Awake()
        {
            if (_onCharacterHealthChangedChannel) _onCharacterHealthChangedChannel.OnRaised += Initialize;
        }

        public void Initialize(float maxHealth)
        {
            _heartCount = Mathf.CeilToInt(maxHealth);

            for (int i = 0; i < _heartCount; i++)
            {
                HealthTrackerHeart heart = Instantiate(_heartPrefab, transform);
                _hearts.Add(heart);
            }

            if (_onCharacterHealthChangedChannel)
            {
                _onCharacterHealthChangedChannel.OnRaised -= Initialize;
                _onCharacterHealthChangedChannel.OnRaised += SetHealth;
            }
        }

        public void SetHealth(float health)
        {
            int flooredHealth = Mathf.FloorToInt(health);
            float remainingHealth = health - flooredHealth;

            for (int i = 0; i < _heartCount; i++)
            {
                HealthTrackerHeart heart = _hearts[i];
                float fillAmount = 0;

                if (i < flooredHealth) fillAmount = 1;
                else if (i == flooredHealth) fillAmount = remainingHealth;

                heart.SetFill(fillAmount);
            }
        }
    }
}
