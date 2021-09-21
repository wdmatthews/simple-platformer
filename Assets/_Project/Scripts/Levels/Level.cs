using UnityEngine;
using Project.Characters;
using Project.Collectibles;
using Project.Environment;
using Project.Events;
using Project.Saving;

namespace Project.Levels
{
    [AddComponentMenu("Project/Levels/Level")]
    [DisallowMultipleComponent]
    public class Level : MonoBehaviour
    {
        [SerializeField] protected Transform _entrance = null;
        [SerializeField] protected Collectible _diamond = null;
        [SerializeField] protected Collectible _key = null;
        [SerializeField] protected Door _door = null;
        [SerializeField] protected ToggleBlock[] _toggleBlocks = { };
        [SerializeField] protected Button[] _buttons = { };
        [SerializeField] protected Collectible[] _checkpoints = { };
        [SerializeField] protected Saw[] _saws = { };
        [SerializeField] protected Player _playerPrefab = null;
        [SerializeField] protected TransformEventChannelSO _onCheckpointCollectedChannel = null;
        [SerializeField] protected EventChannelSO _onCharacterDiedChannel = null;
        [SerializeField] protected BoolEventChannelSO _onLevelCompletedChannel = null;

        protected int _index = 0;
        protected SaveDataLevel _saveData = null;
        protected Player _player = null;
        protected Transform _lastCheckpoint = null;
        public Sprite DiamondSprite => _diamond.Sprite;

        protected void Awake()
        {
            if (_onCheckpointCollectedChannel) _onCheckpointCollectedChannel.OnRaised += SaveProgress;
            if (_onCharacterDiedChannel) _onCharacterDiedChannel.OnRaised += ResetProgress;
        }

        protected void OnDestroy()
        {
            if (_onCheckpointCollectedChannel) _onCheckpointCollectedChannel.OnRaised -= SaveProgress;
            if (_onCharacterDiedChannel) _onCharacterDiedChannel.OnRaised -= ResetProgress;
            if (_player) Destroy(_player.gameObject);
        }

        public void Initialize(int index, SaveDataLevel saveData)
        {
            _index = index;
            _saveData = saveData;
            _player = Instantiate(_playerPrefab, _entrance.position, _entrance.rotation);
            _player.name = _playerPrefab.name;

            if (_saveData.DiamondWasCollected)
            {
                _diamond.Collect();
                _diamond.SaveState();
            }
        }

        public void SaveProgress(Transform checkpoint)
        {
            _lastCheckpoint = checkpoint;
            _diamond.SaveState();
            _key.SaveState();
            _door.SaveState();

            for (int i = _toggleBlocks.Length - 1; i >= 0; i--)
            {
                _toggleBlocks[i].SaveState();
            }

            for (int i = _buttons.Length - 1; i >= 0; i--)
            {
                _buttons[i].SaveState();
            }
        }

        public void ResetProgress()
        {
            _player.Spawn(_lastCheckpoint ?? _entrance);
            _diamond.ResetState();
            _key.ResetState();
            _door.ResetState();

            for (int i = _toggleBlocks.Length - 1; i >= 0; i--)
            {
                _toggleBlocks[i].ResetState();
            }

            for (int i = _buttons.Length - 1; i >= 0; i--)
            {
                _buttons[i].ResetState();
            }

            for (int i = _saws.Length - 1; i >= 0; i--)
            {
                _saws[i].ResetState();
            }
        }

        public void Complete()
        {
            _saveData.WasCompleted = true;
            bool diamondWasCollected = _diamond.WasCollected;
            if (diamondWasCollected) _saveData.DiamondWasCollected = true;
            if (_onLevelCompletedChannel) _onLevelCompletedChannel.Raise(diamondWasCollected);
            _player.gameObject.SetActive(false);
            gameObject.SetActive(false);
        }

        public void Restart()
        {
            gameObject.SetActive(true);
            _player.gameObject.SetActive(true);
            _player.Spawn(_entrance);
            if (!_saveData.DiamondWasCollected) _diamond.ResetState(true);
            _key.ResetState(true);
            _door.ResetState(true);

            for (int i = _toggleBlocks.Length - 1; i >= 0; i--)
            {
                _toggleBlocks[i].ResetState(true);
            }

            for (int i = _buttons.Length - 1; i >= 0; i--)
            {
                _buttons[i].ResetState(true);
            }

            for (int i = _checkpoints.Length - 1; i >= 0; i--)
            {
                _checkpoints[i].ResetState(true);
            }

            for (int i = _saws.Length - 1; i >= 0; i--)
            {
                _saws[i].ResetState();
            }
        }
    }
}
