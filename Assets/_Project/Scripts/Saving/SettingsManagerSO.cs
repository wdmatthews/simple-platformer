using UnityEngine;

namespace Project.Saving
{
    [CreateAssetMenu(fileName = "Settings Manager", menuName = "Project/Saving/Settings Manager")]
    public class SettingsManagerSO : ScriptableObject
    {
        public const string SettingsName = "Settings";

        [System.NonSerialized] public Settings Settings = new Settings();

        public void Save()
        {
            string saveDataJSON = JsonUtility.ToJson(Settings);
            PlayerPrefs.SetString(SettingsName, saveDataJSON);
            PlayerPrefs.Save();
        }

        public Settings Load()
        {
            string settingsJSON = PlayerPrefs.GetString(SettingsName);
            if (settingsJSON.Length > 0) Settings = JsonUtility.FromJson<Settings>(settingsJSON);
            else Settings = new Settings();
            return Settings;
        }

        public void SetMusicVolume(float volume)
        {
            Settings.MusicVolume = volume;
            Save();
        }

        public void SetSFXVolume(float volume)
        {
            Settings.SFXVolume = volume;
            Save();
        }
    }
}
