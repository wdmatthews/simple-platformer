using UnityEngine;
using UnityEngine.UI;
using Project.Events;

namespace Project.UI
{
    [AddComponentMenu("Project/UI/Collectible Tracker")]
    [DisallowMultipleComponent]
    [RequireComponent(typeof(Image))]
    public class CollectibleTracker : MonoBehaviour
    {
        [SerializeField] protected Image _image = null;
        [SerializeField] protected SpriteRendererEventChannelSO _onCollectedChannel = null;

        protected void Awake()
        {
            if (!_image) _image = GetComponent<Image>();
            if (_onCollectedChannel) _onCollectedChannel.OnRaised += SetSprite;
        }

        public void SetSprite(SpriteRenderer renderer)
        {
            _image.sprite = renderer.sprite;
        }
    }
}
