using UnityEngine;
using Project.Environment;

namespace Project.Tests.Environment
{
    public class TestSaw : Saw
    {
        public HazardSO Data { get => _data; set => _data = value; }
        public Vector2[] Waypoints {
            get => _waypoints;
            set
            {
                _waypoints = value;
                _currentWaypointIndex = 1;
                _currentWaypoint = _waypoints[_currentWaypointIndex];
                _waypointCount = _waypoints.Length;
            }
        }

        public int CurrentWaypointIndex => _currentWaypointIndex;
        public Vector2 CurrentWaypoint => _currentWaypoint;
        public int WaypointCount => _waypointCount;
        public bool IsPaused => _isPaused;
        public float PauseTimer => _pauseTimer;
    }
}
