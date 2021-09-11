using UnityEngine;
using Project.Characters;
using Project.Tests.Characters;

namespace Project.Tests
{
    public class CharacterBuilder
    {
        private static CharacterSO _defaultData = null;

        public static CharacterSO DefaultData
        {
            get
            {
                if (_defaultData == null)
                {
                    _defaultData = ScriptableObject.CreateInstance<CharacterSO>();
                    _defaultData.MoveSpeed = 1;
                }

                return _defaultData;
            }
        }

        private CharacterSO _data = null;
        private float _gravityScale = 0;

        public CharacterBuilder WithData(CharacterSO data)
        {
            _data = data;
            return this;
        }

        public CharacterBuilder WithGravityScale(float gravityScale)
        {
            _gravityScale = gravityScale;
            return this;
        }

        public TestCharacter Build()
        {
            GameObject gameObject = new GameObject();
            Rigidbody2D rigidbody = gameObject.AddComponent<Rigidbody2D>();
            rigidbody.gravityScale = _gravityScale;
            TestCharacter character = gameObject.AddComponent<TestCharacter>();
            character.Data = _data ? _data : DefaultData;
            return character;
        }

        public static implicit operator TestCharacter(CharacterBuilder builder) => builder.Build();
    }
}
