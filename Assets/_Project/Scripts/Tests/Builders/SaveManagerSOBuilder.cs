using UnityEngine;
using Project.Saving;

namespace Project.Tests.Builders
{
    public class SaveManagerSOBuilder
    {
        public SaveManagerSO Build()
        {
            return ScriptableObject.CreateInstance<SaveManagerSO>();
        }

        public static implicit operator SaveManagerSO(SaveManagerSOBuilder builder) => builder.Build();
    }
}
