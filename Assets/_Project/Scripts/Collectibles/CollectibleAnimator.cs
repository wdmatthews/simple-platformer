using UnityEngine;

namespace Project.Collectibles
{
    [AddComponentMenu("Project/Collectibles/Collectible Animator")]
    [DisallowMultipleComponent]
    [RequireComponent(typeof(SpriteRenderer))]
    public class CollectibleAnimator : MonoBehaviour
    {
        [SerializeField] private float _animationSpeed = 1;
        [SerializeField] private float _maxScale = 1.25f;
        [SerializeField] private float _minScale = 0.75f;
        [SerializeField] private SpriteRenderer _renderer = null;
        [SerializeField] private Sprite _collectedSprite = null;

        private bool _wasCollected = false;
        protected Sprite _initialSprite = null;

        private void Awake()
        {
            if (!_renderer) _renderer = GetComponent<SpriteRenderer>();
            _initialSprite = _renderer.sprite;
        }

        private void Update()
        {
            if (_wasCollected) return;
            float range = _maxScale - _minScale;
            float middleScale = _minScale + range / 2;
            float scale = Mathf.Sin(_animationSpeed * Time.time) * range / 2 + middleScale;
            transform.localScale = new Vector3(scale, scale, scale);
        }

        public void SetWasCollected(bool value)
        {
            _wasCollected = value;

            if (value)
            {
                _renderer.sprite = _collectedSprite;
                transform.localScale = Vector3.one;
            }
            else _renderer.sprite = _initialSprite;
        }
    }
}
