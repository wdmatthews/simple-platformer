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
            character.TakeDamage(character.Data.MaxHealth / 2);
            Assert.AreEqual(character.Data.MaxHealth / 2, character.Health);
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

        [UnityTest]
        public IEnumerator TakeDamage_MakesInvincible()
        {
            TestCharacter character = A.Character;
            yield return null;
            character.TakeDamage(character.Data.MaxHealth / 2);
            Assert.AreEqual(true, character.IsInvincible);
        }

        [UnityTest]
        public IEnumerator TakeDamage_NotInvincibleIfDead()
        {
            TestCharacter character = A.Character;
            yield return null;
            character.TakeDamage(character.Data.MaxHealth);
            Assert.AreEqual(0, character.Health);
            Assert.AreEqual(true, character.IsDead);
            Assert.AreEqual(false, character.IsInvincible);
        }

        [UnityTest]
        public IEnumerator Spawn_FillsHealthAndSetsPosition()
        {
            TestCharacter character = A.Character;
            Transform spawnPoint = new GameObject().transform;
            spawnPoint.position = new Vector3(1, 0, 0);
            yield return null;
            character.TakeDamage(character.Data.MaxHealth / 2);
            Assert.AreEqual(character.Data.MaxHealth / 2, character.Health);
            Assert.AreNotEqual(spawnPoint.position, character.transform.position);
            character.Spawn(spawnPoint);
            Assert.AreEqual(character.Data.MaxHealth, character.Health);
            Assert.AreEqual(spawnPoint.position, character.transform.position);
        }

        [UnityTest]
        public IEnumerator MakeInvincible_ResetsInvincibleTimer()
        {
            TestCharacter character = A.Character;
            yield return null;
            character.MakeInvincibile();
            Assert.AreEqual(character.Data.InvincibleDuration, character.InvincibleTimer);
        }

        [UnityTest]
        public IEnumerator MakeInvincible_InvincibilityGoesAwayAfterDuration()
        {
            TestCharacter character = A.Character;
            yield return null;
            character.MakeInvincibile();
            Assert.AreEqual(true, character.IsInvincible);
            yield return new WaitForSeconds(character.Data.InvincibleDuration);
            yield return null;
            Assert.AreEqual(false, character.IsInvincible);
        }

        [UnityTest]
        public IEnumerator RemoveInvincibility_RemovesInvincibility()
        {
            TestCharacter character = A.Character;
            yield return null;
            character.MakeInvincibile();
            Assert.AreEqual(true, character.IsInvincible);
            character.RemoveInvincibility();
            Assert.AreEqual(false, character.IsInvincible);
        }

        [Test]
        public void Pause_DisablesCharacter()
        {
            TestCharacter character = A.Character;
            character.Pause();
            Assert.AreEqual(false, character.enabled);
        }

        [Test]
        public void Pause_StopsRigidbody()
        {
            TestCharacter character = A.Character;
            character.Pause();
            Assert.AreEqual(new Vector2(), character.Rigidbody.velocity);
            Assert.AreEqual(0, character.Rigidbody.gravityScale);
        }

        [Test]
        public void Pause_DisablesCollider()
        {
            TestCharacter character = A.Character;
            character.Pause();
            Assert.AreEqual(false, character.Collider.enabled);
        }

        [Test]
        public void Resume_EnablesCharacter()
        {
            TestCharacter character = A.Character;
            character.Pause();
            character.Resume();
            Assert.AreEqual(true, character.enabled);
        }

        [Test]
        public void Resume_ContinuesRigidbody()
        {
            TestCharacter character = A.Character;
            character.Rigidbody.velocity = new Vector2(1, 0);
            character.Pause();
            character.Resume();
            Assert.AreEqual(new Vector2(1, 0), character.Rigidbody.velocity);
            Assert.AreEqual(character.Data.GravityScale, character.Rigidbody.gravityScale);
        }

        [Test]
        public void Resume_EnablesCollider()
        {
            TestCharacter character = A.Character;
            character.Pause();
            character.Resume();
            Assert.AreEqual(true, character.Collider.enabled);
        }
    }
}
