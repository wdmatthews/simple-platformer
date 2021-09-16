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
    }
}
