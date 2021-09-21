using UnityEngine;
using Project.Characters;

namespace Project.Tests.Characters
{
    public class TestCharacter : Character
    {
        public CharacterSO Data { get => _data; set => _data = value; }
        public Rigidbody2D Rigidbody => _rigidbody;
        public BoxCollider2D Collider => _collider;

        public float MoveDirection => _moveDirection;
        public bool ShouldJump => _shouldJump;
        public float Health => _health;
        public bool IsInvincible => _isInvincible;
        public float InvincibleTimer => _invincibleTimer;
    }
}
