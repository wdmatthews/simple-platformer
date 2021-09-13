using UnityEngine;
using Project.Environment;

namespace Project.Tests.Environment
{
    public class TestPortal : Portal
    {
        public Transform LinkedPortal { get => _linkedPortal; set => _linkedPortal = value; }
    }
}
