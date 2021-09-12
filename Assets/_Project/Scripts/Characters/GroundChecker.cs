using UnityEngine;

namespace Project.Characters
{
    [AddComponentMenu("Project/Characters/Ground Checker")]
    [DisallowMultipleComponent]
    public class GroundChecker : MonoBehaviour
    {
        [SerializeField] private Vector2 _size = new Vector2(0.9f, 0.1f);
        [SerializeField] private float _offset = -0.5f;
        [SerializeField] private LayerMask _groundLayers = 0;

        private bool _isGrounded = false;

        public bool IsGrounded
        {
            get
            {
                _isGrounded = Physics2D.BoxCast(transform.position, _size, 0, Vector2.down, _offset, _groundLayers);
                return _isGrounded;
            }
        }

#if UNITY_EDITOR
        private void OnDrawGizmosSelected()
        {
            float leftX = transform.position.x - _size.x / 2;
            float rightX = transform.position.x + _size.x / 2;
            float bottomY = transform.position.y - _size.y / 2 - _offset;
            float topY = transform.position.y + _size.y / 2 - _offset;

            Gizmos.color = _isGrounded ? Color.red : Color.green;
            Gizmos.DrawLine(new Vector3(leftX, bottomY), new Vector3(leftX, topY));
            Gizmos.DrawLine(new Vector3(rightX, bottomY), new Vector3(rightX, topY));
            Gizmos.DrawLine(new Vector3(leftX, bottomY), new Vector3(rightX, bottomY));
            Gizmos.DrawLine(new Vector3(leftX, topY), new Vector3(rightX, topY));
        }
#endif
    }
}
