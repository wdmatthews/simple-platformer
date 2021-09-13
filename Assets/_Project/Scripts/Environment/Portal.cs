using UnityEngine;

namespace Project.Environment
{
    [AddComponentMenu("Project/Environment/Portal")]
    [DisallowMultipleComponent]
    [RequireComponent(typeof(CircleCollider2D))]
    public class Portal : MonoBehaviour
    {
        [SerializeField] protected string _characterLayerName = "Character";
        [SerializeField] protected float _teleportPositionTolerance = 0.05f;
        [SerializeField] protected CircleCollider2D _collider = null;
        [SerializeField] protected Transform _linkedPortal = null;

        protected int _characterLayer = 0;
        protected bool _wasEntered = false;

        protected void Awake()
        {
            if (!_collider) _collider = GetComponent<CircleCollider2D>();
            _collider.enabled = false;
            _characterLayer = LayerMask.NameToLayer(_characterLayerName);
        }

        protected void LateUpdate()
        {
            if (!_collider.enabled)
            {
                _wasEntered = false;
                _collider.enabled = true;
            }
        }

        protected void OnTriggerEnter2D(Collider2D collision)
        {
            bool isDirectlyOnPortal = Vector3.Distance(transform.position,
                collision.transform.position) < _teleportPositionTolerance;
            if (!_wasEntered && collision.gameObject.layer == _characterLayer
                && !isDirectlyOnPortal) Enter(collision.transform);
        }

        public void Enter(Transform character)
        {
            _wasEntered = true;
            _collider.enabled = false;
            character.transform.position = _linkedPortal.transform.position;
        }
    }
}
