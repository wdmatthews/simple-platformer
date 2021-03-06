using UnityEngine;
using Project.Characters;
using Project.Tests.Characters;

namespace Project.Tests.Builders
{
    public class CharacterBuilder
    {
        private static CharacterSO _defaultData = null;

        public static CharacterSO DefaultData
        {
            get
            {
                if (!_defaultData)
                {
                    _defaultData = ScriptableObject.CreateInstance<CharacterSO>();
                    _defaultData.GravityScale = 0;
                    _defaultData.MaxHealth = 3;
                }

                return _defaultData;
            }
        }

        private CharacterSO _data = null;

        public CharacterBuilder WithData(CharacterSO data)
        {
            _data = data;
            return this;
        }

        public TestCharacter Build()
        {
            GameObject gameObject = new GameObject();
            TestCharacter character = gameObject.AddComponent<TestCharacter>();
            character.Data = _data ? _data : DefaultData;
            return character;
        }

        public static implicit operator TestCharacter(CharacterBuilder builder) => builder.Build();
    }
}
