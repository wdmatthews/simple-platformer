using UnityEngine;

namespace Project.Environment
{
    [AddComponentMenu("Project/Environment/Toggle Block")]
    [DisallowMultipleComponent]
    [RequireComponent(typeof(BoxCollider2D))]
    [RequireComponent(typeof(SpriteRenderer))]
    public class ToggleBlock : MonoBehaviour
    {
        [SerializeField] protected Sprite _onSprite = null;
        [SerializeField] protected Sprite _offSprite = null;
        [SerializeField] protected BoxCollider2D _collider = null;
        [SerializeField] protected SpriteRenderer _renderer = null;

        protected bool _isOn = true;
        protected bool _wasOnWhenSaved = true;

        protected void Awake()
        {
            if (!_collider) _collider = GetComponent<BoxCollider2D>();
            if (!_renderer) _renderer = GetComponent<SpriteRenderer>();
        }

        public void Toggle()
        {
            _isOn = !_isOn;
            _collider.enabled = _isOn;
            _renderer.sprite = _isOn ? _onSprite : _offSprite;
        }

        public void SaveState()
        {
            _wasOnWhenSaved = _isOn;
        }

        public void ResetState(bool ignoreSavedState = false)
        {
            _isOn = ignoreSavedState || _wasOnWhenSaved;
            _collider.enabled = _isOn;
            _renderer.sprite = _isOn ? _onSprite : _offSprite;
        }
    }
}
