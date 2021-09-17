using NUnit.Framework;
using Project.Saving;
using Project.Tests.Builders;
using Project.Tests.Levels;

namespace Project.Tests.PlayMode
{
    public class LevelTests
    {
        [Test]
        public void Initialize_SpawnsPlayer()
        {
            TestLevel level = A.Level;
            level.Initialize(0, new SaveDataLevel());
            Assert.IsNotNull(level.Player);
        }

        [Test]
        public void Initialize_SpawnsDiamondIf_CollectedInSave()
        {
            TestLevel level = A.Level;
            level.Initialize(0, new SaveDataLevel(true, false));
            Assert.AreEqual(false, level.Diamond.WasCollected);
            level = A.Level;
            level.Initialize(0, new SaveDataLevel(true, true));
            Assert.AreEqual(true, level.Diamond.WasCollected);
        }
    }
}
