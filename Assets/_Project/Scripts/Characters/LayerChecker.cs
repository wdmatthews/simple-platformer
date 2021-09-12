using UnityEngine;

namespace Project.Characters
{
    [AddComponentMenu("Project/Characters/Layer Checker")]
    public class LayerChecker : MonoBehaviour
    {
        [SerializeField] private Vector2 _size = new Vector2(0.9f, 0.1f);
        [SerializeField] private float _offset = 0.55f;
        [SerializeField] private LayerMask _layers = 0;

        private bool _isTouching = false;

        public bool IsTouching
        {
            get
            {
                RaycastHit2D hit = Physics2D.BoxCast(transform.position, _size, 0,
                    Vector2.down, _offset, _layers);
                TouchedCollider = hit.collider;
                _isTouching = hit;
                return _isTouching;
            }
        }

        public Collider2D TouchedCollider { get; private set; }

#if UNITY_EDITOR
        private void OnDrawGizmosSelected()
        {
            Gizmos.color = _isTouching ? Color.red : Color.green;
            DrawBox(_offset, _size);
        }

        private void DrawBox(float offset, Vector2 size)
        {
            float leftX = transform.position.x - size.x / 2;
            float rightX = transform.position.x + size.x / 2;
            float bottomY = transform.position.y - size.y / 2 - offset;
            float topY = transform.position.y + size.y / 2 - offset;

            Gizmos.DrawLine(new Vector3(leftX, bottomY), new Vector3(leftX, topY));
            Gizmos.DrawLine(new Vector3(rightX, bottomY), new Vector3(rightX, topY));
            Gizmos.DrawLine(new Vector3(leftX, bottomY), new Vector3(rightX, bottomY));
            Gizmos.DrawLine(new Vector3(leftX, topY), new Vector3(rightX, topY));
        }
#endif
    }
}
