using UnityEngine;
using Project.Characters;
using Project.Collectibles;
using Project.Environment;
using Project.Saving;

namespace Project.Levels
{
    [AddComponentMenu("Project/Levels/Level")]
    [DisallowMultipleComponent]
    public class Level : MonoBehaviour
    {
        [SerializeField] protected Transform _entrance = null;
        [SerializeField] protected Collectible _diamond = null;
        [SerializeField] protected Player _playerPrefab = null;

        protected int _index = 0;
        protected SaveDataLevel _saveData = null;
        protected Player _player = null;

        protected void OnDestroy()
        {
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
    }
}
