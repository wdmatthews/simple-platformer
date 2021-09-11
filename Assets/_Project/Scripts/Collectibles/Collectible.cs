using UnityEngine;

namespace Project.Collectibles
{
    [AddComponentMenu("Project/Collectibles/Collectible")]
    [DisallowMultipleComponent]
    [RequireComponent(typeof(CircleCollider2D))]
    public class Collectible : MonoBehaviour
    {
        [SerializeField] protected CollectibleSO _data = null;
        [SerializeField] protected CircleCollider2D _collider = null;

        protected int _collectorLayer = 0;
        protected bool _wasCollected = false;

        protected void Awake()
        {
            if (!_collider) _collider = GetComponent<CircleCollider2D>();
        }

        protected void Start()
        {
            _collectorLayer = LayerMask.NameToLayer(_data.CollectorLayer);
        }

        protected void OnTriggerEnter2D(Collider2D collision)
        {
            if (!_wasCollected && collision.gameObject.layer == _collectorLayer) Collect();
        }

        public void Collect()
        {
            _wasCollected = true;
            _collider.enabled = false;
        }
    }
}
