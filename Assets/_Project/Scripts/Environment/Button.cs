using UnityEngine;
using UnityEngine.Events;

namespace Project.Environment
{
    [AddComponentMenu("Project/Environment/Button")]
    [DisallowMultipleComponent]
    [RequireComponent(typeof(BoxCollider2D))]
    public class Button : MonoBehaviour
    {
        [SerializeField] protected string _characterLayerName = "Character";
        [SerializeField] protected BoxCollider2D _collider = null;
        [SerializeField] protected UnityEvent _onPress = null;

        protected int _characterLayer = 0;
        protected bool _wasPressed = false;

        protected void Awake()
        {
            if (!_collider) _collider = GetComponent<BoxCollider2D>();
            _characterLayer = LayerMask.NameToLayer(_characterLayerName);
        }

        protected void OnTriggerEnter2D(Collider2D collision)
        {
            if (!_wasPressed && collision.gameObject.layer == _characterLayer) Press();
        }

        public void Press()
        {
            _wasPressed = true;
            _collider.enabled = false;
            _onPress?.Invoke();
        }

        public void Reset()
        {
            _wasPressed = false;
            _collider.enabled = true;
        }
    }
}
