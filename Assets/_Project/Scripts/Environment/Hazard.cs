using UnityEngine;
using Project.Characters;
using Project.Events;

namespace Project.Environment
{
    public abstract class Hazard : MonoBehaviour
    {
        [SerializeField] protected HazardSO _data = null;
        [SerializeField] protected string _characterLayerName = "Character";
        [SerializeField] protected EventChannelSO _onCharacterDiedChannel = null;

        protected int _characterLayer = 0;
        protected Character _characterInTrigger = null;

        protected virtual void Awake()
        {
            _characterLayer = LayerMask.NameToLayer(_characterLayerName);
            _onCharacterDiedChannel.OnRaised += ResetCharacterInTrigger;
        }

        protected virtual void Update()
        {
            if (_characterInTrigger) DamageCharacter(_characterInTrigger);
        }

        protected virtual void OnDestroy()
        {
            _onCharacterDiedChannel.OnRaised -= ResetCharacterInTrigger;
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

        protected void OnTriggerExit2D(Collider2D collision) => ResetCharacterInTrigger();

        public void ResetCharacterInTrigger()
        {
            _characterInTrigger = null;
        }

        public void DamageCharacter(Character character)
        {
            character.TakeDamage(_data.Damage);
        }
    }
}
