using NUnit.Framework;
using UnityEngine;
using Project.Saving;
using Project.Tests.Builders;
using Project.Tests.Environment;
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
        public void SaveProgress_SavesDiamondState()
        {
            TestLevel level = A.Level;
            level.Initialize(0, new SaveDataLevel());
            level.Diamond.Collect();
            level.SaveProgress(null);
            Assert.AreEqual(true, level.Diamond.CollectionWasSaved);
        }

        [Test]
        public void SaveProgress_SavesKeyState()
        {
            TestLevel level = A.Level;
            level.Initialize(0, new SaveDataLevel());
            level.Key.Collect();
            level.SaveProgress(null);
            Assert.AreEqual(true, level.Key.CollectionWasSaved);
        }

        [Test]
        public void SaveProgress_SavesToggleStates()
        {
            TestToggleBlock[] toggleBlocks = new TestToggleBlock[] { A.ToggleBlock, A.ToggleBlock };
            TestLevel level = A.Level.WithToggleBlocks(toggleBlocks);
            level.Initialize(0, new SaveDataLevel());
            toggleBlocks[1].Toggle();
            level.SaveProgress(null);
            Assert.AreEqual(true, toggleBlocks[0].WasOnWhenSaved);
            Assert.AreEqual(false, toggleBlocks[1].WasOnWhenSaved);
        }

        [Test]
        public void SaveProgress_SavesButtonStates()
        {
            TestButton[] buttons = new TestButton[] { A.Button, A.Button };
            buttons[0].ResetOnTriggerExit = false;
            buttons[1].ResetOnTriggerExit = false;
            TestLevel level = A.Level.WithButtons(buttons);
            level.Initialize(0, new SaveDataLevel());
            buttons[0].Press();
            level.SaveProgress(null);
            Assert.AreEqual(true, buttons[0].WasPressedWhenSaved);
            Assert.AreEqual(false, buttons[1].WasPressedWhenSaved);
        }
    }
}
