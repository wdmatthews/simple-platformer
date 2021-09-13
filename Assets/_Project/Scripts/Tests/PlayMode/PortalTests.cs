using NUnit.Framework;
using UnityEngine;
using Project.Tests.Builders;
using Project.Tests.Environment;

namespace Project.Tests.PlayMode
{
    public class PortalTests
    {
        [Test]
        public void Enter_TeleportsCharacter()
        {
            TestPortal portal1 = A.Portal.WithPosition(new Vector3());
            TestPortal portal2 = A.Portal.WithPosition(new Vector3(1, 0));
            portal1.LinkedPortal = portal2.transform;
            portal2.LinkedPortal = portal1.transform;
            GameObject character = new GameObject();
            portal1.Enter(character.transform);
            Assert.AreEqual(portal2.transform.position, character.transform.position);
        }
    }
}
