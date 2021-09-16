using UnityEngine;
using UnityEngine.Events;

namespace Project.Environment
{
    [AddComponentMenu("Project/Environment/Button")]
    [DisallowMultipleComponent]
    [RequireComponent(typeof(BoxCollider2D))]
    [RequireComponent(typeof(SpriteRenderer))]
    public class Button : MonoBehaviour
    {
        [SerializeField] protected bool _resetOnTriggerExit = true;
        [SerializeField] protected string _characterLayerName = "Character";
        [SerializeField] protected Sprite _normalSprite = null;
        [SerializeField] protected Sprite _pressedSprite = null;
        [SerializeField] protected BoxCollider2D _collider = null;
        [SerializeField] protected SpriteRenderer _renderer = null;
        [SerializeField] protected UnityEvent _onPress = null;

        protected int _characterLayer = 0;
        protected bool _wasPressed = false;

        protected void Awake()
        {
            if (!_collider) _collider = GetComponent<BoxCollider2D>();
            if (!_renderer) _renderer = GetComponent<SpriteRenderer>();
            _characterLayer = LayerMask.NameToLayer(_characterLayerName);
        }

        protected void OnTriggerEnter2D(Collider2D collision)
        {
            if (!_wasPressed && collision.gameObject.layer == _characterLayer) Press();
        }

        protected void OnTriggerExit2D(Collider2D collision)
        {
            if (_wasPressed && _resetOnTriggerExit
                && collision.gameObject.layer == _characterLayer)
            {
                Reset();
            }
        }

        public void Press()
        {
            _wasPressed = true;
            if (!_resetOnTriggerExit) _collider.enabled = false;
            _onPress?.Invoke();
            _renderer.sprite = _pressedSprite;
        }

        public void Reset()
        {
            _wasPressed = false;
            if (!_resetOnTriggerExit) _collider.enabled = true;
            _renderer.sprite = _normalSprite;
        }
    }
}
