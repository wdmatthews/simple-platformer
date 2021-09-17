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

        [Test]
        public void SaveState_SavesAsOn()
        {
            TestToggleBlock toggleBlock = A.ToggleBlock;
            toggleBlock.SaveState();
            Assert.AreEqual(true, toggleBlock.WasOnWhenSaved);
        }

        [Test]
        public void SaveState_SavesAsOff()
        {
            TestToggleBlock toggleBlock = A.ToggleBlock;
            toggleBlock.Toggle();
            toggleBlock.SaveState();
            Assert.AreEqual(false, toggleBlock.WasOnWhenSaved);
        }

        [Test]
        public void ResetState_ResetsToOn()
        {
            TestToggleBlock toggleBlock = A.ToggleBlock;
            toggleBlock.SaveState();
            toggleBlock.Toggle();
            Assert.AreEqual(false, toggleBlock.IsOn);
            toggleBlock.ResetState();
            Assert.AreEqual(true, toggleBlock.IsOn);
        }

        [Test]
        public void ResetState_ResetsToOff()
        {
            TestToggleBlock toggleBlock = A.ToggleBlock;
            toggleBlock.Toggle();
            toggleBlock.SaveState();
            toggleBlock.Toggle();
            Assert.AreEqual(true, toggleBlock.IsOn);
            toggleBlock.ResetState();
            Assert.AreEqual(false, toggleBlock.IsOn);
        }
    }
}
