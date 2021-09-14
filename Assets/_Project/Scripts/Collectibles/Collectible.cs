using UnityEngine;
using UnityEngine.Events;

namespace Project.Collectibles
{
    [AddComponentMenu("Project/Collectibles/Collectible")]
    [DisallowMultipleComponent]
    [RequireComponent(typeof(CircleCollider2D))]
    [RequireComponent(typeof(CollectibleAnimator))]
    public class Collectible : MonoBehaviour
    {
        [SerializeField] protected string _characterLayerName = "Character";
        [SerializeField] protected CircleCollider2D _collider = null;
        [SerializeField] protected CollectibleAnimator _animator = null;
        [SerializeField] protected UnityEvent<Transform> _onCollect = null;

        protected int _characterLayer = 0;
        protected bool _wasCollected = false;

        protected void Awake()
        {
            if (!_collider) _collider = GetComponent<CircleCollider2D>();
            if (!_animator) _animator = GetComponent<CollectibleAnimator>();
            _characterLayer = LayerMask.NameToLayer(_characterLayerName);
        }

        protected void Start()
        {
            _animator.SetWasCollected(false);
        }

        protected void OnTriggerEnter2D(Collider2D collision)
        {
            if (!_wasCollected && collision.gameObject.layer == _characterLayer) Collect();
        }

        public void Collect()
        {
            _wasCollected = true;
            _collider.enabled = false;
            _onCollect?.Invoke(transform);
            _animator.SetWasCollected(_wasCollected);
        }
    }
}
