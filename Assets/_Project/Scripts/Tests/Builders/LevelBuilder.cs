using UnityEngine;
using Project.Tests.Characters;
using Project.Tests.Collectibles;
using Project.Tests.Levels;

namespace Project.Tests.Builders
{
    public class LevelBuilder
    {
        private Transform _entrance = null;
        private TestCollectible _diamond = null;
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

        public LevelBuilder WithPlayerPrefab(TestPlayer playerPrefab)
        {
            _playerPrefab = playerPrefab;
            return this;
        }

        public TestLevel Build()
        {
            GameObject gameObject = new GameObject();
            TestLevel level = gameObject.AddComponent<TestLevel>();
            level.Entrance = _entrance ? _entrance : new GameObject().transform;
            level.Diamond = _diamond ? _diamond : A.Collectible;
            level.PlayerPrefab = _playerPrefab ? _playerPrefab : A.Player;
            return level;
        }

        public static implicit operator TestLevel(LevelBuilder builder) => builder.Build();
    }
}
