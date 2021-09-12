using NUnit.Framework;
using Project.Tests.Builders;
using Project.Tests.Environment;

namespace Project.Tests.PlayMode
{
    public class DoorTests
    {
        [Test]
        public void Unlock_EnablesCollider()
        {
            TestDoor door = A.Door;
            door.Unlock();
            Assert.AreEqual(true, door.WasUnlocked);
            Assert.AreEqual(true, door.Collider.enabled);
        }

        [Test]
        public void Enter_DisablesCollider()
        {
            TestDoor door = A.Door;
            door.Collider.enabled = true;
            door.Enter();
            Assert.AreEqual(true, door.WasEntered);
            Assert.AreEqual(false, door.Collider.enabled);
        }
    }
}
