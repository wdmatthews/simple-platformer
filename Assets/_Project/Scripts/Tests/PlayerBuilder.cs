using UnityEngine;
using Project.Characters;
using Project.Tests.Characters;

namespace Project.Tests
{
    public class PlayerBuilder
    {
        private CharacterSO _data = null;

        public PlayerBuilder WithData(CharacterSO data)
        {
            _data = data;
            return this;
        }

        public TestPlayer Build()
        {
            GameObject gameObject = new GameObject();
            TestPlayer player = gameObject.AddComponent<TestPlayer>();
            player.GetComponent<GroundChecker>().enabled = false;
            player.Data = _data ? _data : CharacterBuilder.DefaultData;
            return player;
        }

        public static implicit operator TestPlayer(PlayerBuilder builder) => builder.Build();
    }
}
