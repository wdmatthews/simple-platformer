using UnityEngine;
using Project.Tests.Environment;

namespace Project.Tests.Builders
{
    public class ButtonBuilder
    {
        public TestButton Build()
        {
            GameObject gameObject = new GameObject();
            TestButton button = gameObject.AddComponent<TestButton>();
            return button;
        }

        public static implicit operator TestButton(ButtonBuilder builder) => builder.Build();
    }
}
