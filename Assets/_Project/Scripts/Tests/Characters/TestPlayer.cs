using UnityEngine;
using UnityEngine.InputSystem;
using Project.Characters;

namespace Project.Tests.Characters
{
    public class TestPlayer : Player
    {
        public CharacterSO Data { get => _data; set => _data = value; }
        public Rigidbody2D Rigidbody => _rigidbody;
        public PlayerInput Input => _input;

        public float MoveDirection => _moveDirection;
        public bool ShouldJump => _shouldJump;
        public float Health => _health;
        public bool IsDead => _isDead;
    }
}
