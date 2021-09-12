using UnityEngine;
using Project.Environment;
using Project.Tests.Environment;

namespace Project.Tests.Builders
{
    public class SpikeBuilder
    {
        private static HazardSO _defaultData = null;

        public static HazardSO DefaultData
        {
            get
            {
                if (!_defaultData)
                {
                    _defaultData = ScriptableObject.CreateInstance<HazardSO>();
                }

                return _defaultData;
            }
        }

        private HazardSO _data = null;

        public SpikeBuilder WithData(HazardSO data)
        {
            _data = data;
            return this;
        }

        public TestSpike Build()
        {
            GameObject gameObject = new GameObject();
            TestSpike spike = gameObject.AddComponent<TestSpike>();
            spike.Data = _data ? _data : DefaultData;
            return spike;
        }

        public static implicit operator TestSpike(SpikeBuilder builder) => builder.Build();
    }
}
