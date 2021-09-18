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
        public void SaveProgress_SavesDoorState()
        {
            TestLevel level = A.Level;
            level.Initialize(0, new SaveDataLevel());
            level.Door.Unlock();
            level.SaveProgress(null);
            Assert.AreEqual(true, level.Door.WasUnlockedWhenSaved);
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

        [Test]
        public void ResetProgress_SpawnsPlayerAtEntrance()
        {
            TestLevel level = A.Level;
            level.Initialize(0, new SaveDataLevel());
            level.SaveProgress(null);
            level.Player.transform.position = new Vector3(1, 0, 0);
            level.ResetProgress();
            Assert.AreEqual(level.Entrance.position, level.Player.transform.position);
        }

        [Test]
        public void ResetProgress_SpawnsPlayerAtCheckpoint()
        {
            TestLevel level = A.Level;
            level.Initialize(0, new SaveDataLevel());
            Transform checkpoint = new GameObject().transform;
            level.SaveProgress(checkpoint);
            level.Player.transform.position = new Vector3(1, 0, 0);
            level.ResetProgress();
            Assert.AreEqual(level.LastCheckpoint.position, level.Player.transform.position);
        }

        [Test]
        public void ResetProgress_ResetsDiamondState()
        {
            TestLevel level = A.Level;
            level.Initialize(0, new SaveDataLevel());
            level.SaveProgress(null);
            level.Diamond.Collect();
            level.ResetProgress();
            Assert.AreEqual(false, level.Diamond.WasCollected);
        }

        [Test]
        public void ResetProgress_ResetsKeyState()
        {
            TestLevel level = A.Level;
            level.Initialize(0, new SaveDataLevel());
            level.SaveProgress(null);
            level.Key.Collect();
            level.ResetProgress();
            Assert.AreEqual(false, level.Key.WasCollected);
        }

        [Test]
        public void ResetProgress_ResetsDoorState()
        {
            TestLevel level = A.Level;
            level.Initialize(0, new SaveDataLevel());
            level.SaveProgress(null);
            level.Door.Unlock();
            level.ResetProgress();
            Assert.AreEqual(false, level.Door.WasUnlocked);
        }

        [Test]
        public void ResetProgress_ResetsToggleStates()
        {
            TestToggleBlock[] toggleBlocks = new TestToggleBlock[] { A.ToggleBlock };
            TestLevel level = A.Level.WithToggleBlocks(toggleBlocks);
            level.Initialize(0, new SaveDataLevel());
            level.SaveProgress(null);
            toggleBlocks[0].Toggle();
            level.ResetProgress();
            Assert.AreEqual(true, toggleBlocks[0].IsOn);
        }

        [Test]
        public void ResetProgress_ResetsButtonStates()
        {
            TestButton[] buttons = new TestButton[] { A.Button };
            buttons[0].ResetOnTriggerExit = false;
            TestLevel level = A.Level.WithButtons(buttons);
            level.Initialize(0, new SaveDataLevel());
            level.SaveProgress(null);
            buttons[0].Press();
            level.ResetProgress();
            Assert.AreEqual(false, buttons[0].WasPressed);
        }

        [Test]
        public void Restart_SpawnsPlayerAtEntrance()
        {
            TestLevel level = A.Level;
            level.Initialize(0, new SaveDataLevel());
            level.Player.transform.position = new Vector3(1, 0, 0);
            level.Restart();
            Assert.AreEqual(level.Entrance.position, level.Player.transform.position);
        }

        [Test]
        public void Restart_ResetsDiamondStateToNotCollected()
        {
            TestLevel level = A.Level;
            level.Initialize(0, new SaveDataLevel());
            level.Diamond.Collect();
            level.Restart();
            Assert.AreEqual(false, level.Diamond.WasCollected);
        }

        [Test]
        public void Restart_ResetsDiamondStateToCollectedWhenSaved()
        {
            TestLevel level = A.Level;
            level.Initialize(0, new SaveDataLevel(false, true));
            level.Restart();
            Assert.AreEqual(true, level.Diamond.WasCollected);
        }

        [Test]
        public void Restart_ResetsKeyState()
        {
            TestLevel level = A.Level;
            level.Initialize(0, new SaveDataLevel());
            level.Key.Collect();
            level.Restart();
            Assert.AreEqual(false, level.Key.WasCollected);
        }

        [Test]
        public void Restart_ResetsDoorState()
        {
            TestLevel level = A.Level;
            level.Initialize(0, new SaveDataLevel());
            level.Door.Unlock();
            level.Restart();
            Assert.AreEqual(false, level.Door.WasUnlocked);
        }

        [Test]
        public void Restart_ResetsToggleStates()
        {
            TestToggleBlock[] toggleBlocks = new TestToggleBlock[] { A.ToggleBlock };
            TestLevel level = A.Level.WithToggleBlocks(toggleBlocks);
            level.Initialize(0, new SaveDataLevel());
            toggleBlocks[0].Toggle();
            level.Restart();
            Assert.AreEqual(true, toggleBlocks[0].IsOn);
        }

        [Test]
        public void Restart_ResetsButtonStates()
        {
            TestButton[] buttons = new TestButton[] { A.Button };
            buttons[0].ResetOnTriggerExit = false;
            TestLevel level = A.Level.WithButtons(buttons);
            level.Initialize(0, new SaveDataLevel());
            buttons[0].Press();
            level.Restart();
            Assert.AreEqual(false, buttons[0].WasPressed);
        }
    }
}
