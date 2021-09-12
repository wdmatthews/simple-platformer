using NUnit.Framework;
using Project.Tests.Builders;
using Project.Tests.Environment;

namespace Project.Tests.PlayMode
{
    public class ToggleBlockGroupTests
    {
        [Test]
        public void Toggle_TogglesToggleBlocks()
        {
            TestToggleBlock[] toggleBlocks = new TestToggleBlock[] { A.ToggleBlock, A.ToggleBlock };
            TestToggleBlockGroup toggleBlockGroup = A.ToggleBlockGroup.WithToggleBlocks(toggleBlocks);
            bool wasOn = toggleBlockGroup.IsOn;
            toggleBlockGroup.Toggle();
            Assert.AreEqual(!wasOn, toggleBlockGroup.IsOn);
            Assert.AreEqual(!wasOn, toggleBlocks[0].IsOn);
        }
    }
}
