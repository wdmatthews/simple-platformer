using UnityEngine;
using Project.Tests.Environment;

namespace Project.Tests.Builders
{
    public class PortalBuilder
    {
        private Vector3 _position = new Vector3();

        public PortalBuilder WithPosition(Vector3 position)
        {
            _position = position;
            return this;
        }

        public TestPortal Build()
        {
            GameObject gameObject = new GameObject();
            TestPortal portal = gameObject.AddComponent<TestPortal>();
            portal.transform.position = _position;
            return portal;
        }

        public static implicit operator TestPortal(PortalBuilder builder) => builder.Build();
    }
}
