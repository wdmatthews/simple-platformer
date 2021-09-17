using UnityEngine;

namespace Project.Saving
{
    [CreateAssetMenu(fileName = "Save Manager", menuName = "Project/Saving/Save Manager")]
    public class SaveManagerSO : ScriptableObject
    {
        public const string SaveDataName = "Save Data";

        [System.NonSerialized] public SaveData SaveData = new SaveData();

        public void Save()
        {
            string saveDataJSON = JsonUtility.ToJson(SaveData);
            PlayerPrefs.SetString(SaveDataName, saveDataJSON);
            PlayerPrefs.Save();
        }

        public SaveData Load()
        {
            string saveDataJSON = PlayerPrefs.GetString(SaveDataName);
            if (saveDataJSON.Length > 0) SaveData = JsonUtility.FromJson<SaveData>(saveDataJSON);
            else SaveData = new SaveData();
            return SaveData;
        }
    }
}
