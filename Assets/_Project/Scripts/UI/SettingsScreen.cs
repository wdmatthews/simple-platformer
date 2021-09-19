using UnityEngine;
using UnityEngine.UI;
using Project.Saving;

namespace Project.UI
{
    [AddComponentMenu("Project/UI/Settings Screen")]
    [DisallowMultipleComponent]
    public class SettingsScreen : MonoBehaviour
    {
        [SerializeField] private Slider _musicVolumeSlider = null;
        [SerializeField] private Slider _sfxVolumeSlider = null;
        [SerializeField] private SettingsManagerSO _settingsManager = null;

        private void Awake()
        {
            _settingsManager.Load();
            _musicVolumeSlider.value = _settingsManager.Settings.MusicVolume;
            _sfxVolumeSlider.value = _settingsManager.Settings.SFXVolume;
        }
    }
}
