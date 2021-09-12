using UnityEngine;
using Project.Environment;
using Project.Tests.Environment;

namespace Project.Tests.Builders
{
    public class SawBuilder
    {
        private static HazardSO _defaultData = null;

        public static HazardSO DefaultData
        {
            get
            {
                if (!_defaultData)
                {
                    _defaultData = ScriptableObject.CreateInstance<HazardSO>();
                    _defaultData.MoveSpeed = 1;
                    _defaultData.PauseDuration = 1;
                }

                return _defaultData;
            }
        }

        private HazardSO _data = null;
        private Vector2[] _waypoints = { new Vector2(), new Vector2(1, 0) };

        public SawBuilder WithData(HazardSO data)
        {
            _data = data;
            return this;
        }

        public SawBuilder WithWaypoints(Vector2[] waypoints)
        {
            _waypoints = waypoints;
            return this;
        }

        public TestSaw Build()
        {
            GameObject gameObject = new GameObject();
            TestSaw saw = gameObject.AddComponent<TestSaw>();
            saw.Data = _data ? _data : DefaultData;
            saw.Waypoints = _waypoints;
            saw.transform.position = _waypoints[0];
            return saw;
        }

        public static implicit operator TestSaw(SawBuilder builder) => builder.Build();
    }
}
