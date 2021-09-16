using System;
using UnityEngine;

namespace Project.Events
{
    [CreateAssetMenu(fileName = "New Event", menuName = "Project/Events/Event")]
    public class EventChannelSO : ScriptableObject
    {
        public Action OnRaised = null;

        public void Raise() => OnRaised?.Invoke();
    }
}
