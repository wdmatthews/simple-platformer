using NUnit.Framework;
using Project.Tests.Builders;
using Project.Tests.Environment;

namespace Project.Tests.PlayMode
{
    public class ButtonTests
    {
        [Test]
        public void Press_DisablesCollider()
        {
            TestButton button = A.Button;
            button.Press();
            Assert.AreEqual(true, button.WasPressed);
            Assert.AreEqual(false, button.Collider.enabled);
        }

        [Test]
        public void Reset_EnablesCollider()
        {
            TestButton button = A.Button;
            button.Press();
            button.Reset();
            Assert.AreEqual(false, button.WasPressed);
            Assert.AreEqual(true, button.Collider.enabled);
        }
    }
}
