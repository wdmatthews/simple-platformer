using UnityEngine;

namespace Project.Environment
{
    [AddComponentMenu("Project/Environment/Saw")]
    [DisallowMultipleComponent]
    [RequireComponent(typeof(CircleCollider2D))]
    public class Saw : Hazard
    {
        [SerializeField] protected Vector2[] _waypoints = { };

        protected int _currentWaypointIndex = 0;
        protected Vector2 _currentWaypoint = new Vector2();
        protected int _waypointCount = 0;
        protected bool _isPaused = false;
        protected float _pauseTimer = 0;

        protected override void Awake()
        {
            base.Awake();
            _currentWaypointIndex = 1;
            _waypointCount = _waypoints.Length;

            if (_currentWaypointIndex < _waypointCount)
            {
                _currentWaypoint = _waypoints[_currentWaypointIndex];
            }
        }

        protected override void Update()
        {
            base.Update();

            if (_isPaused)
            {
                if (Mathf.Approximately(_pauseTimer, 0)) Resume();
                else _pauseTimer = Mathf.Clamp(_pauseTimer - Time.deltaTime, 0, _data.PauseDuration);
            }
            else
            {
                Vector2 newPosition = Vector2.MoveTowards(transform.position,
                                _currentWaypoint, Time.deltaTime * _data.MoveSpeed);
                transform.position = newPosition;

                if (Mathf.Approximately(newPosition.x, _currentWaypoint.x)
                    && Mathf.Approximately(newPosition.y, _currentWaypoint.y))
                {
                    _currentWaypointIndex++;
                    if (_currentWaypointIndex >= _waypointCount) _currentWaypointIndex = 0;
                    _currentWaypoint = _waypoints[_currentWaypointIndex];
                    Pause();
                }
            }
        }

        public void Pause()
        {
            _isPaused = true;
            _pauseTimer = _data.PauseDuration;
        }

        public void Resume()
        {
            _isPaused = false;
        }

#if UNITY_EDITOR
        protected void OnDrawGizmosSelected()
        {
            Gizmos.color = Color.yellow;

            foreach (Vector2 waypoint in _waypoints)
            {
                Gizmos.DrawWireSphere(waypoint, 0.1f);
            }
        }
#endif
    }
}
