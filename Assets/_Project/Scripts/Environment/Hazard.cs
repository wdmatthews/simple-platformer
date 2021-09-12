using UnityEngine;
using Project.Characters;

namespace Project.Environment
{
    public abstract class Hazard : MonoBehaviour
    {
        [SerializeField] protected HazardSO _data = null;
        [SerializeField] protected string _characterLayerName = "Character";
        [SerializeField] protected CharacterFloatEventChannelSO _damageCharacterChannel = null;

        protected int _characterLayer = 0;

        protected void Awake()
        {
            _characterLayer = LayerMask.NameToLayer(_characterLayerName);
        }

        protected void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.gameObject.layer == _characterLayer)
            {
                _damageCharacterChannel.Raise(collision.GetComponent<Character>(), _data.Damage);
            }
        }
    }
}
