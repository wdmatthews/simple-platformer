using UnityEngine;
using Project.Characters;

namespace Project.Environment
{
    public abstract class Hazard : MonoBehaviour
    {
        [SerializeField] protected HazardSO _data = null;
        [SerializeField] protected string _characterLayerName = "Character";

        protected int _characterLayer = 0;
        protected Character _characterInTrigger = null;

        protected void Awake()
        {
            _characterLayer = LayerMask.NameToLayer(_characterLayerName);
        }

        protected void Update()
        {
            if (_characterInTrigger) DamageCharacter(_characterInTrigger);
        }

        protected void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.gameObject.layer == _characterLayer)
            {
                Character character = collision.GetComponent<Character>();
                _characterInTrigger = character;
                DamageCharacter(character);
            }
        }

        protected void OnTriggerExit2D(Collider2D collision)
        {
            _characterInTrigger = null;
        }

        public void DamageCharacter(Character character)
        {
            character.TakeDamage(_data.Damage);
        }
    }
}
