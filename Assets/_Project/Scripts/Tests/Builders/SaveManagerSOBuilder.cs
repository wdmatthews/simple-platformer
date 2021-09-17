using UnityEngine;
using Project.Saving;

namespace Project.Tests.Builders
{
    public class SaveManagerSOBuilder
    {
        public SaveManagerSO Build()
        {
            SaveManagerSO manager = ScriptableObject.CreateInstance<SaveManagerSO>();
            return manager;
        }

        public static implicit operator SaveManagerSO(SaveManagerSOBuilder builder) => builder.Build();
    }
}
