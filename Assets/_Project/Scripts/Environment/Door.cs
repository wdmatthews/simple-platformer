using UnityEngine;
using UnityEngine.Events;
using Project.Audio;

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
        [SerializeField] protected AudioClip _openClip = null;
        [SerializeField] protected AudioClip _enterClip = null;
        [SerializeField] protected AudioManagerSO _audioManager = null;

        protected int _characterLayer = 0;
        protected bool _wasUnlocked = false;
        protected bool _wasUnlockedWhenSaved = false;
        protected bool _wasEntered = false;
        protected Sprite _lockedBottomSprite = null;
        protected Sprite _lockedTopSprite = null;

        protected void Awake()
        {
            if (!_collider) _collider = GetComponent<BoxCollider2D>();
            _collider.enabled = false;
            _characterLayer = LayerMask.NameToLayer(_characterLayerName);
            if (_bottomRenderer) _lockedBottomSprite = _bottomRenderer.sprite;
            if (_topRenderer) _lockedTopSprite = _topRenderer.sprite;
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
            if (_audioManager) _audioManager.PlaySFX(_openClip);
        }

        public void Enter()
        {
            _wasEntered = true;
            _collider.enabled = false;
            _onEnter?.Invoke();
            if (_audioManager) _audioManager.PlaySFX(_enterClip);
        }

        public void SaveState()
        {
            _wasUnlockedWhenSaved = _wasUnlocked;
        }

        public void ResetState(bool ignoreSavedState = false)
        {
            _wasUnlocked = !ignoreSavedState && _wasUnlockedWhenSaved;
            _wasEntered = false;
            _collider.enabled = _wasUnlocked;

            if (_bottomRenderer && _topRenderer)
            {
                _bottomRenderer.sprite = _wasUnlocked ? _unlockedBottomSprite : _lockedBottomSprite;
                _topRenderer.sprite = _wasUnlocked ? _unlockedTopSprite : _lockedTopSprite;
            }
        }
    }
}
