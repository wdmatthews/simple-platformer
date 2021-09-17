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
        [SerializeField] protected Player _playerPrefab = null;
        [SerializeField] protected TransformEventChannelSO _onCheckpointCollectedChannel = null;

        protected int _index = 0;
        protected SaveDataLevel _saveData = null;
        protected Player _player = null;
        protected Transform _lastCheckpoint = null;

        protected void Awake()
        {
            if (_onCheckpointCollectedChannel) _onCheckpointCollectedChannel.OnRaised += SaveProgress;
        }

        protected void OnDestroy()
        {
            if (_onCheckpointCollectedChannel) _onCheckpointCollectedChannel.OnRaised -= SaveProgress;
            if (_player) Destroy(_player.gameObject);
        }

        public void Initialize(int index, SaveDataLevel saveData)
        {
            _index = index;
            _saveData = saveData;
            _player = Instantiate(_playerPrefab, _entrance.position, _entrance.rotation);
            _player.name = _playerPrefab.name;

            if (_saveData.DiamondWasCollected) _diamond.Collect();
        }

        public void SaveProgress(Transform checkpoint)
        {
            _lastCheckpoint = checkpoint;
            _diamond.SaveProgress();
            _key.SaveProgress();
        }
    }
}
