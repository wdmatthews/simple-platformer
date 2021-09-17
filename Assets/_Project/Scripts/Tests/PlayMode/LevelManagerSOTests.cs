using NUnit.Framework;
using Project.Tests.Builders;
using Project.Tests.Levels;

namespace Project.Tests.PlayMode
{
    public class LevelManagerSOTests
    {
        [Test]
        public void Load_SpawnsLevel()
        {
            TestLevelManagerSO levelManager = A.LevelManagerSO
                .WithLevels(new TestLevel[] { A.Level });
            levelManager.Load();
            Assert.IsNotNull(levelManager.LoadedLevel);
        }

        [Test]
        public void Load_FillsEmptySave()
        {
            TestLevelManagerSO levelManager = A.LevelManagerSO
                .WithLevels(new TestLevel[] { A.Level });
            levelManager.Load();
            Assert.AreEqual(levelManager.Levels.Length, levelManager.SaveManager.SaveData.Levels.Length);
        }

        [Test]
        public void Unload_DestroysLevel()
        {
            TestLevelManagerSO levelManager = A.LevelManagerSO
                .WithLevels(new TestLevel[] { A.Level });
            levelManager.Load();
            levelManager.Unload();
            Assert.IsNull(levelManager.LoadedLevel);
        }
    }
}
