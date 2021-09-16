using System;
using UnityEngine;

namespace Project.Events
{
    public abstract class OneTypeEventChannelSO<T> : ScriptableObject
    {
        public Action<T> OnRaised = null;

        public void Raise(T data) => OnRaised?.Invoke(data);
    }
}
