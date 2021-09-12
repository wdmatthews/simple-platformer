using NUnit.Framework;
using Project.Tests.Builders;
using Project.Tests.Environment;

namespace Project.Tests.PlayMode
{
    public class ToggleBlockTests
    {
        [Test]
        public void Toggle_TogglesCollider()
        {
            TestToggleBlock toggleBlock = A.ToggleBlock;
            bool wasOn = toggleBlock.IsOn;
            toggleBlock.Toggle();
            Assert.AreEqual(!wasOn, toggleBlock.IsOn);
            Assert.AreEqual(!wasOn, toggleBlock.Collider.enabled);
        }
    }
}
