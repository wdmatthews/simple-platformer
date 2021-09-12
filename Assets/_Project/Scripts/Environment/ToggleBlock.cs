using UnityEngine;

namespace Project.Environment
{
    [AddComponentMenu("Project/Environment/Toggle Block")]
    [DisallowMultipleComponent]
    [RequireComponent(typeof(BoxCollider2D))]
    public class ToggleBlock : MonoBehaviour
    {
        [SerializeField] protected BoxCollider2D _collider = null;

        protected bool _isOn = true;

        protected void Awake()
        {
            if (!_collider) _collider = GetComponent<BoxCollider2D>();
        }

        public void Toggle()
        {
            _isOn = !_isOn;
            _collider.enabled = _isOn;
        }
    }
}
