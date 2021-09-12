using UnityEngine;

namespace Project.Collectibles
{
    [AddComponentMenu("Project/Collectibles/Collectible")]
    [DisallowMultipleComponent]
    [RequireComponent(typeof(CircleCollider2D))]
    public class Collectible : MonoBehaviour
    {
        [SerializeField] protected string _characterLayerName = "Character";
        [SerializeField] protected CircleCollider2D _collider = null;

        protected int _characterLayer = 0;
        protected bool _wasCollected = false;

        protected void Awake()
        {
            if (!_collider) _collider = GetComponent<CircleCollider2D>();
            _characterLayer = LayerMask.NameToLayer(_characterLayerName);
        }

        protected void OnTriggerEnter2D(Collider2D collision)
        {
            if (!_wasCollected && collision.gameObject.layer == _characterLayer) Collect();
        }

        public void Collect()
        {
            _wasCollected = true;
            _collider.enabled = false;
        }
    }
}
