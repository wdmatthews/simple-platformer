using UnityEngine;
using UnityEngine.Events;

namespace Project.Environment
{
    [AddComponentMenu("Project/Environment/Door")]
    [DisallowMultipleComponent]
    [RequireComponent(typeof(BoxCollider2D))]
    public class Door : MonoBehaviour
    {
        [SerializeField] protected string _characterLayerName = "Character";
        [SerializeField] protected Sprite _unlockedBottomSprite = null;
        [SerializeField] protected Sprite _unlockedTopSprite = null;
        [SerializeField] protected BoxCollider2D _collider = null;
        [SerializeField] protected SpriteRenderer _bottomRenderer = null;
        [SerializeField] protected SpriteRenderer _topRenderer = null;
        [SerializeField] protected UnityEvent _onEnter = null;

        protected int _characterLayer = 0;
        protected bool _wasUnlocked = false;
        protected bool _wasEntered = false;

        protected void Awake()
        {
            if (!_collider) _collider = GetComponent<BoxCollider2D>();
            _collider.enabled = false;
            _characterLayer = LayerMask.NameToLayer(_characterLayerName);
        }

        protected void OnTriggerEnter2D(Collider2D collision)
        {
            if (!_wasEntered && collision.gameObject.layer == _characterLayer) Enter();
        }

        public void Unlock()
        {
            _wasUnlocked = true;
            _collider.enabled = true;
            if (_bottomRenderer) _bottomRenderer.sprite = _unlockedBottomSprite;
            if (_topRenderer) _topRenderer.sprite = _unlockedTopSprite;
        }

        public void Enter()
        {
            _wasEntered = true;
            _collider.enabled = false;
            _onEnter?.Invoke();
        }
    }
}
