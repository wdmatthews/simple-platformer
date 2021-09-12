using UnityEngine;
using Project.Characters;

namespace Project.Environment
{
    public abstract class Hazard : MonoBehaviour
    {
        [SerializeField] protected HazardSO _data = null;
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
                DamageCharacter(collision.GetComponent<Character>());
            }
        }

        public void DamageCharacter(Character character)
        {
            character.TakeDamage(_data.Damage);
        }
    }
}
