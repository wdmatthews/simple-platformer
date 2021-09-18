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

        [Test]
        public void SaveState_SavesAsUnlocked()
        {
            TestDoor door = A.Door;
            door.Unlock();
            door.SaveState();
            Assert.AreEqual(true, door.WasUnlockedWhenSaved);
        }

        [Test]
        public void SaveState_SavesAsLocked()
        {
            TestDoor door = A.Door;
            door.SaveState();
            Assert.AreEqual(false, door.WasUnlockedWhenSaved);
        }

        [Test]
        public void ResetState_ResetsToUnlocked()
        {
            TestDoor door = A.Door;
            door.Unlock();
            door.SaveState();
            Assert.AreEqual(true, door.WasUnlockedWhenSaved);
            door.ResetState();
            Assert.AreEqual(true, door.WasUnlocked);
        }

        [Test]
        public void ResetState_ResetsToLocked()
        {
            TestDoor door = A.Door;
            door.SaveState();
            Assert.AreEqual(false, door.WasUnlockedWhenSaved);
            door.ResetState();
            Assert.AreEqual(false, door.WasUnlocked);
        }
    }
}
