using UnityEngine;
using UnityEngine.Events;
using Project.Events;

namespace Project.Collectibles
{
    [AddComponentMenu("Project/Collectibles/Collectible")]
    [DisallowMultipleComponent]
    [RequireComponent(typeof(CircleCollider2D))]
    [RequireComponent(typeof(CollectibleAnimator))]
    [RequireComponent(typeof(SpriteRenderer))]
    public class Collectible : MonoBehaviour
    {
        [SerializeField] protected string _characterLayerName = "Character";
        [SerializeField] protected CircleCollider2D _collider = null;
        [SerializeField] protected CollectibleAnimator _animator = null;
        [SerializeField] protected SpriteRenderer _spriteRenderer = null;
        [SerializeField] protected SpriteRendererEventChannelSO _onCollectedChannel = null;
        [SerializeField] protected UnityEvent<Transform> _onCollected = null;

        protected int _characterLayer = 0;
        protected bool _wasCollected = false;

        protected void Awake()
        {
            if (!_collider) _collider = GetComponent<CircleCollider2D>();
            if (!_animator) _animator = GetComponent<CollectibleAnimator>();
            if (!_spriteRenderer) _spriteRenderer = GetComponent<SpriteRenderer>();
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
            _onCollected?.Invoke(transform);
            if (_onCollectedChannel) _onCollectedChannel.Raise(_spriteRenderer);
            _animator.SetWasCollected(_wasCollected);
        }
    }
}
