using UnityEngine;
using Project.Tests.Environment;

namespace Project.Tests.Builders
{
    public class ToggleBlockBuilder
    {
        public TestToggleBlock Build()
        {
            GameObject gameObject = new GameObject();
            TestToggleBlock toggleBlock = gameObject.AddComponent<TestToggleBlock>();
            return toggleBlock;
        }

        public static implicit operator TestToggleBlock(ToggleBlockBuilder builder) => builder.Build();
    }
}
