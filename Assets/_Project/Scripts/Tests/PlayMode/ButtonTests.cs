using NUnit.Framework;
using Project.Tests.Builders;
using Project.Tests.Environment;

namespace Project.Tests.PlayMode
{
    public class ButtonTests
    {
        [Test]
        public void Press_DisablesColliderIf_NotResetOnTriggerExit()
        {
            TestButton button = A.Button;
            button.ResetOnTriggerExit = false;
            button.Press();
            Assert.AreEqual(true, button.WasPressed);
            Assert.AreEqual(false, button.Collider.enabled);
        }

        [Test]
        public void Reset_EnablesColliderIf_NotResetOnTriggerExit()
        {
            TestButton button = A.Button;
            button.ResetOnTriggerExit = false;
            button.Press();
            button.Reset();
            Assert.AreEqual(false, button.WasPressed);
            Assert.AreEqual(true, button.Collider.enabled);
        }

        [Test]
        public void SaveState_SavesAsPressed()
        {
            TestButton button = A.Button;
            button.ResetOnTriggerExit = false;
            button.Press();
            button.SaveState();
            Assert.AreEqual(true, button.WasPressedWhenSaved);
        }

        [Test]
        public void SaveState_SavesAsNotPressed()
        {
            TestButton button = A.Button;
            button.ResetOnTriggerExit = false;
            Assert.AreEqual(false, button.WasPressedWhenSaved);
        }

        [Test]
        public void ResetState_ResetsToPressed()
        {
            TestButton button = A.Button;
            button.ResetOnTriggerExit = false;
            button.Press();
            button.SaveState();
            button.Reset();
            Assert.AreEqual(false, button.WasPressed);
            button.ResetState();
            Assert.AreEqual(true, button.WasPressed);
        }

        [Test]
        public void ResetState_ResetsToNotPressed()
        {
            TestButton button = A.Button;
            button.ResetOnTriggerExit = false;
            button.SaveState();
            button.Press();
            Assert.AreEqual(true, button.WasPressed);
            button.ResetState();
            Assert.AreEqual(false, button.WasPressed);
        }
    }
}
