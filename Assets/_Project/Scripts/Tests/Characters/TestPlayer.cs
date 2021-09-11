using UnityEngine;
using Project.Characters;

namespace Project.Tests.Characters
{
    public class TestPlayer : Player
    {
        public CharacterSO Data { get => _data; set => _data = value; }
        public Rigidbody2D Rigidbody => _rigidbody;

        public float MoveDirection => _moveDirection;
    }
}
