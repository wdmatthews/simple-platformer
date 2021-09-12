using UnityEngine;
using Project.Tests.Environment;

namespace Project.Tests.Builders
{
    public class ToggleBlockGroupBuilder
    {
        private TestToggleBlock[] _toggleBlocks = { };

        public ToggleBlockGroupBuilder WithToggleBlocks(TestToggleBlock[] toggleBlocks)
        {
            _toggleBlocks = toggleBlocks;
            return this;
        }

        public TestToggleBlockGroup Build()
        {
            GameObject gameObject = new GameObject();
            TestToggleBlockGroup toggleBlockGroup = gameObject.AddComponent<TestToggleBlockGroup>();
            toggleBlockGroup.Blocks = _toggleBlocks;
            return toggleBlockGroup;
        }

        public static implicit operator TestToggleBlockGroup(ToggleBlockGroupBuilder builder) => builder.Build();
    }
}
