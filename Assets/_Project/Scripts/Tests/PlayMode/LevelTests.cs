using NUnit.Framework;
using UnityEngine;
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

        [Test]
        public void SaveProgress_SetsCheckpoint()
        {
            TestLevel level = A.Level;
            level.Initialize(0, new SaveDataLevel());
            Transform checkpoint = new GameObject().transform;
            level.SaveProgress(checkpoint);
            Assert.AreEqual(checkpoint, level.LastCheckpoint);
        }

        [Test]
        public void SaveProgress_SavesDiamondProgress()
        {
            TestLevel level = A.Level;
            level.Initialize(0, new SaveDataLevel());
            level.Diamond.Collect();
            level.SaveProgress(null);
            Assert.AreEqual(true, level.Diamond.CollectionWasSaved);
        }

        [Test]
        public void SaveProgress_SavesKeyProgress()
        {
            TestLevel level = A.Level;
            level.Initialize(0, new SaveDataLevel());
            level.Key.Collect();
            level.SaveProgress(null);
            Assert.AreEqual(true, level.Key.CollectionWasSaved);
        }
    }
}
