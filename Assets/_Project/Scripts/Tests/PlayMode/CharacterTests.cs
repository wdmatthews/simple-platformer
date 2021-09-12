using System.Collections;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using Project.Tests.Builders;
using Project.Tests.Characters;

namespace Project.Tests.PlayMode
{
    public class CharacterTests
    {
        [UnityTest]
        public IEnumerator MoveLeft_SetsXVelocity_NegativeMoveSpeed()
        {
            TestCharacter character = A.Character;
            character.Move(-1);
            yield return new WaitForFixedUpdate();
            Assert.AreEqual(-character.Data.MoveSpeed, character.Rigidbody.velocity.x);
        }

        [UnityTest]
        public IEnumerator MoveRight_SetsXVelocity_PositiveMoveSpeed()
        {
            TestCharacter character = A.Character;
            character.Move(1);
            yield return new WaitForFixedUpdate();
            Assert.AreEqual(character.Data.MoveSpeed, character.Rigidbody.velocity.x);
        }

        [Test]
        public void MoveLeft_WhenFacingRight_NowFacingLeft()
        {
            TestCharacter character = A.Character;
            character.Move(-1);
            Assert.AreEqual(180, character.transform.eulerAngles.y);
        }

        [Test]
        public void MoveRight_WhenFacingLeft_NowFacingRight()
        {
            TestCharacter character = A.Character;
            character.Move(-1);
            Assert.AreEqual(180, character.transform.eulerAngles.y);
            character.Move(1);
            Assert.AreEqual(0, character.transform.eulerAngles.y);
        }

        [Test]
        public void MoveLeft_WhenFacingLeft_StillFacingLeft()
        {
            TestCharacter character = A.Character;
            character.Move(-1);
            Assert.AreEqual(180, character.transform.eulerAngles.y);
            character.Move(-1);
            Assert.AreEqual(180, character.transform.eulerAngles.y);
        }

        [Test]
        public void MoveRight_WhenFacingRight_StillFacingRight()
        {
            TestCharacter character = A.Character;
            character.Move(1);
            Assert.AreEqual(0, character.transform.eulerAngles.y);
            character.Move(1);
            Assert.AreEqual(0, character.transform.eulerAngles.y);
        }

        [Test]
        public void Jump_SetsYVelocity_JumpSpeed()
        {
            TestCharacter character = A.Character;
            character.Jump();
            Assert.AreEqual(character.Data.JumpSpeed, character.Rigidbody.velocity.y);
        }

        [UnityTest]
        public IEnumerator TakeDamage_LosesHealth()
        {
            TestCharacter character = A.Character;
            yield return null;
            Assert.AreEqual(character.Data.MaxHealth, character.Health);
            character.TakeDamage(0.5f);
            Assert.AreEqual(character.Data.MaxHealth - 0.5f, character.Health);
        }

        [UnityTest]
        public IEnumerator TakeDamage_DiesAtZeroHealth()
        {
            TestCharacter character = A.Character;
            yield return null;
            character.TakeDamage(character.Data.MaxHealth);
            Assert.AreEqual(0, character.Health);
            Assert.AreEqual(true, character.IsDead);
        }
    }
}
