using System;
using UnityEngine;

namespace Project.Events
{
    [CreateAssetMenu(fileName = "New Event", menuName = "Project/Events/Event")]
    public class EventChannelSO : ScriptableObject
    {
        public Action OnRaise = null;

        public void Raise() => OnRaise?.Invoke();
    }
}
