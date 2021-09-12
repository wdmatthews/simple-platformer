using UnityEngine;
using Project.Characters;

namespace Project.Environment
{
    [AddComponentMenu("Project/Environment/Liquid")]
    [DisallowMultipleComponent]
    public class Liquid : MonoBehaviour
    {
        [SerializeField] protected string _characterLayerName = "Character";

        protected int _characterLayer = 0;

        protected void Awake()
        {
            _characterLayer = LayerMask.NameToLayer(_characterLayerName);
        }

        protected void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.gameObject.layer == _characterLayer)
            {
                KillCharacter(collision.GetComponent<Character>());
            }
        }

        public void KillCharacter(Character character)
        {
            character.Die();
        }
    }
}
