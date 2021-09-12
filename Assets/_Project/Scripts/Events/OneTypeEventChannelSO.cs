using System;
using UnityEngine;

namespace Project.Events
{
    public abstract class OneTypeEventChannelSO<T> : ScriptableObject
    {
        public Action<T> OnRaise = null;

        public void Raise(T data) => OnRaise?.Invoke(data);
    }
}
