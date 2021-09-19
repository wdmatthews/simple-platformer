using UnityEngine;
using Project.Saving;

namespace Project.Audio
{
    [CreateAssetMenu(fileName = "Audio Manager", menuName = "Project/Audio/Audio Manager")]
    [DisallowMultipleComponent]
    public class AudioManagerSO : ScriptableObject
    {
        [SerializeField] private SettingsManagerSO _settingsManager = null;

        [System.NonSerialized] public AudioSource MusicSource = null;
        [System.NonSerialized] public AudioSource SFXSource = null;

        public void PlayMusic(AudioClip clip)
        {
            MusicSource.Stop();
            MusicSource.clip = clip;
            MusicSource.volume = _settingsManager.Settings.MusicVolume;
            MusicSource.Play();
        }

        public void PlaySFX(AudioClip clip)
        {
            SFXSource.Stop();
            SFXSource.clip = clip;
            SFXSource.volume = _settingsManager.Settings.SFXVolume;
            SFXSource.Play();
        }
    }
}
