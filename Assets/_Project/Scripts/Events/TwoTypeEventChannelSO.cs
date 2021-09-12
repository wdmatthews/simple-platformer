using System;
using UnityEngine;

namespace Project.Events
{
    public abstract class TwoTypeEventChannelSO<T1, T2> : ScriptableObject
    {
        public Action<T1, T2> OnRaise = null;

        public void Raise(T1 data1, T2 data2) => OnRaise?.Invoke(data1, data2);
    }
}
