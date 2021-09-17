using UnityEngine;
using Project.Tests.Characters;
using Project.Tests.Collectibles;
using Project.Tests.Environment;
using Project.Tests.Levels;

namespace Project.Tests.Builders
{
    public class LevelBuilder
    {
        private Transform _entrance = null;
        private TestCollectible _diamond = null;
        private TestCollectible _key = null;
        private TestToggleBlock[] _toggleBlocks = null;
        private TestButton[] _buttons = null;
        private TestPlayer _playerPrefab = null;

        public LevelBuilder WithEntrance(Transform entrance)
        {
            _entrance = entrance;
            return this;
        }

        public LevelBuilder WithDiamond(TestCollectible diamond)
        {
            _diamond = diamond;
            return this;
        }

        public LevelBuilder WithKey(TestCollectible key)
        {
            _key = key;
            return this;
        }

        public LevelBuilder WithPlayerPrefab(TestPlayer playerPrefab)
        {
            _playerPrefab = playerPrefab;
            return this;
        }

        public LevelBuilder WithToggleBlocks(TestToggleBlock[] toggleBlocks)
        {
            _toggleBlocks = toggleBlocks;
            return this;
        }

        public LevelBuilder WithButtons(TestButton[] buttons)
        {
            _buttons = buttons;
            return this;
        }

        public TestLevel Build()
        {
            GameObject gameObject = new GameObject();
            TestLevel level = gameObject.AddComponent<TestLevel>();
            level.Entrance = _entrance ? _entrance : new GameObject().transform;
            level.Diamond = _diamond ? _diamond : A.Collectible;
            level.Key = _key ? _key : A.Collectible;
            if (_toggleBlocks != null) level.SetToggleBlocks(_toggleBlocks);
            if (_buttons != null) level.SetButtons(_buttons);
            level.PlayerPrefab = _playerPrefab ? _playerPrefab : A.Player;
            return level;
        }

        public static implicit operator TestLevel(LevelBuilder builder) => builder.Build();
    }
}
