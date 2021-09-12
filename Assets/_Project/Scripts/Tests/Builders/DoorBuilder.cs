using UnityEngine;
using Project.Tests.Environment;

namespace Project.Tests.Builders
{
    public class DoorBuilder
    {
        public TestDoor Build()
        {
            GameObject gameObject = new GameObject();
            TestDoor door = gameObject.AddComponent<TestDoor>();
            return door;
        }

        public static implicit operator TestDoor(DoorBuilder builder) => builder.Build();
    }
}
