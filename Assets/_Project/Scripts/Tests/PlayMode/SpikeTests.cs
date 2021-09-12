using System.Collections;
using NUnit.Framework;
using UnityEngine.TestTools;
using Project.Tests.Builders;
using Project.Tests.Characters;
using Project.Tests.Environment;

namespace Project.Tests.PlayMode
{
    public class SpikeTests
    {
        [UnityTest]
        public IEnumerator DamageCharacter_DamagesCharacter()
        {
            TestSpike spike = A.Spike;
            TestCharacter character = A.Character;
            yield return null;
            spike.DamageCharacter(character);
            Assert.AreEqual(character.Data.MaxHealth - spike.Data.Damage, character.Health);
        }
    }
}
