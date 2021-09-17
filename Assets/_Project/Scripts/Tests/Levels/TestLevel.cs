using UnityEngine;
using Project.Tests.Characters;
using Project.Tests.Collectibles;
using Project.Levels;
using Project.Saving;

namespace Project.Tests.Levels
{
    public class TestLevel : Level
    {
        public Transform Entrance { get => _entrance; set => _entrance = value; }
        public TestCollectible Diamond { get => (TestCollectible)_diamond; set => _diamond = value; }
        public TestCollectible Key { get => (TestCollectible)_key; set => _key = value; }
        public TestPlayer PlayerPrefab { get => (TestPlayer)_playerPrefab; set => _playerPrefab = value; }

        public int Index => _index;
        public SaveDataLevel SaveData => _saveData;
        public TestPlayer Player => (TestPlayer)_player;
        public Transform LastCheckpoint => _lastCheckpoint;
    }
}
