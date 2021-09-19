using UnityEngine;

namespace Project.Audio
{
    [AddComponentMenu("Project/Audio/Audio Player")]
    [DisallowMultipleComponent]
    [RequireComponent(typeof(AudioSource))]
    public class AudioPlayer : MonoBehaviour
    {
        [SerializeField] private bool _isMusic = true;
        [SerializeField] private bool _playOnStart = true;
        [SerializeField] private AudioSource _source = null;
        [SerializeField] private AudioManagerSO _audioManager = null;

        private void Awake()
        {
            if (_source == null) _source = GetComponent<AudioSource>();
            if (_isMusic) _audioManager.MusicSource = _source;
            else _audioManager.SFXSource = _source;
        }

        private void Start()
        {
            if (_playOnStart) _audioManager.PlayMusic(_source.clip);
        }
    }
}
