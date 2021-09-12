using UnityEngine;

namespace Project.Characters
{
    [CreateAssetMenu(fileName = "New Character", menuName = "Project/Characters/Character")]
    public class CharacterSO : ScriptableObject
    {
        public float MoveSpeed = 1;
        public float JumpSpeed = 1;
        public float GravityScale = 1;
        public float MaxHealth = 1;
    }
}
