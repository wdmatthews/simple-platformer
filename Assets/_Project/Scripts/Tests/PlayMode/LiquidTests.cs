using NUnit.Framework;
using Project.Environment;
using Project.Tests.Builders;
using Project.Tests.Characters;

namespace Project.Tests.PlayMode
{
    public class LiquidTests
    {
        [Test]
        public void KillCharacter_KillsCharacter()
        {
            Liquid liquid = A.Liquid;
            TestCharacter character = A.Character;
            liquid.KillCharacter(character);
            Assert.AreEqual(true, character.IsDead);
        }
    }
}
