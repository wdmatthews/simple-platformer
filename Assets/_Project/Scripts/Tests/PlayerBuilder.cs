using UnityEngine;
using Project.Characters;
using Project.Tests.Characters;

namespace Project.Tests
{
    public class PlayerBuilder
    {
        private CharacterSO _data = null;
        private float _gravityScale = 0;

        public PlayerBuilder WithData(CharacterSO data)
        {
            _data = data;
            return this;
        }

        public PlayerBuilder WithGravityScale(float gravityScale)
        {
            _gravityScale = gravityScale;
            return this;
        }

        public TestPlayer Build()
        {
            GameObject gameObject = new GameObject();
            Rigidbody2D rigidbody = gameObject.AddComponent<Rigidbody2D>();
            rigidbody.gravityScale = _gravityScale;
            TestPlayer player = gameObject.AddComponent<TestPlayer>();
            player.Data = _data ? _data : CharacterBuilder.DefaultData;
            return player;
        }

        public static implicit operator TestPlayer(PlayerBuilder builder) => builder.Build();
    }
}
