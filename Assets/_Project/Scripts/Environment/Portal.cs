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
        [SerializeField] protected float _spinSpeed = 1f;
        [SerializeField] protected int _spinDirection = 1;
        [SerializeField] protected Transform _linkedPortal = null;

        protected int _characterLayer = 0;

        protected void Awake()
        {
            _characterLayer = LayerMask.NameToLayer(_characterLayerName);
        }

        protected void Update()
        {
            transform.eulerAngles += new Vector3(0, 0, Time.deltaTime * _spinSpeed * _spinDirection);
        }

        protected void OnTriggerEnter2D(Collider2D collision)
        {
            bool isDirectlyOnPortal = Vector3.Distance(transform.position,
                collision.transform.position) < _teleportPositionTolerance;
            if (collision.gameObject.layer == _characterLayer
                && !isDirectlyOnPortal) Enter(collision.transform);
        }

        public void Enter(Transform character)
        {
            character.transform.position = _linkedPortal.transform.position;
        }
    }
}
