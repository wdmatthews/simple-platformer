using UnityEngine;
using UnityEngine.UI;
using Project.Events;

namespace Project.UI
{
    [AddComponentMenu("Project/UI/Key Tracker")]
    [DisallowMultipleComponent]
    [RequireComponent(typeof(Image))]
    public class KeyTracker : MonoBehaviour
    {
        [SerializeField] protected Image _image = null;
        [SerializeField] protected SpriteRendererEventChannelSO _onKeyCollectedChannel = null;

        protected void Awake()
        {
            if (!_image) _image = GetComponent<Image>();
            if (_onKeyCollectedChannel) _onKeyCollectedChannel.OnRaised += SetSprite;
        }

        public void SetSprite(SpriteRenderer renderer)
        {
            _image.sprite = renderer.sprite;
        }
    }
}
