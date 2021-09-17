using NUnit.Framework;
using UnityEngine;
using Project.Saving;
using Project.Tests.Builders;

namespace Project.Tests.EditMode
{
    public class SaveManagerSOTests
    {
        [Test]
        public void Save_SavesDataToPlayerPrefs()
        {
            PlayerPrefs.DeleteKey(SaveManagerSO.SaveDataName);
            SaveManagerSO saveManager = A.SaveManagerSO;
            saveManager.SaveData.Levels = new SaveDataLevel[] {
                new SaveDataLevel(true, false)
            };
            saveManager.Save();
            Assert.IsNotEmpty(PlayerPrefs.GetString(SaveManagerSO.SaveDataName));
        }

        [Test]
        public void Load_LoadsDataFromPlayerPrefs()
        {
            PlayerPrefs.SetString(SaveManagerSO.SaveDataName,
                "{\"Levels\":[{\"WasCompleted\":true,\"DiamondWasCollected\":false}]}");
            PlayerPrefs.Save();
            SaveManagerSO saveManager = A.SaveManagerSO;
            saveManager.Load();
            Assert.AreEqual(1, saveManager.SaveData.Levels.Length);
            SaveDataLevel savedLevel = saveManager.SaveData.Levels[0];
            Assert.AreEqual(true, savedLevel.WasCompleted);
            Assert.AreEqual(false, savedLevel.DiamondWasCollected);
        }
    }
}
