using UnityEngine;

namespace Project.Environment
{
    [AddComponentMenu("Project/Environment/Door")]
    [DisallowMultipleComponent]
    [RequireComponent(typeof(BoxCollider2D))]
    public class Door : MonoBehaviour
    {
        [SerializeField] protected string _characterLayerName = "Character";
        [SerializeField] protected BoxCollider2D _collider = null;

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
        }

        public void Enter()
        {
            _wasEntered = true;
            _collider.enabled = false;
        }
    }
}
