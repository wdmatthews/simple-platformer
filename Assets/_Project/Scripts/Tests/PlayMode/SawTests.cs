using System.Collections;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using Project.Tests.Builders;
using Project.Tests.Characters;
using Project.Tests.Environment;

namespace Project.Tests.PlayMode
{
    public class SawTests
    {
        [UnityTest]
        public IEnumerator DamageCharacter_DamagesCharacter()
        {
            TestSaw saw = A.Saw;
            TestCharacter character = A.Character;
            yield return null;
            saw.DamageCharacter(character);
            Assert.AreEqual(character.Data.MaxHealth - saw.Data.Damage, character.Health);
        }

        [UnityTest]
        public IEnumerator Move_MovesToCurrentWaypoint()
        {
            Vector2[] waypoints = new Vector2[] { new Vector2(), new Vector2(1, 0) };
            TestSaw saw = A.Saw.WithWaypoints(waypoints);
            yield return new WaitForSeconds(saw.Data.MoveSpeed * (waypoints[1].x - waypoints[0].x));
            Assert.AreEqual(waypoints[1],
                new Vector2(saw.transform.position.x, saw.transform.position.y));
        }

        [UnityTest]
        public IEnumerator Move_ChangesCurrentWaypoint_WhenArrivingAtCurrent()
        {
            Vector2[] waypoints = new Vector2[] { new Vector2(), new Vector2(1, 0) };
            TestSaw saw = A.Saw.WithWaypoints(waypoints);
            saw.transform.position = waypoints[1];
            yield return null;
            Assert.AreEqual(0, saw.CurrentWaypointIndex);
            Assert.AreEqual(waypoints[0], saw.CurrentWaypoint);
        }

        [UnityTest]
        public IEnumerator Move_Pauses_WhenArrivingAtCurrent()
        {
            Vector2[] waypoints = new Vector2[] { new Vector2(), new Vector2(1, 0) };
            TestSaw saw = A.Saw.WithWaypoints(waypoints);
            saw.transform.position = waypoints[1];
            yield return null;
            Vector3 positionBeforePause = saw.transform.position;
            Assert.AreEqual(true, saw.IsPaused);
            yield return null;
            Assert.AreEqual(positionBeforePause, saw.transform.position);
        }

        [Test]
        public void Pause_ResetsPauseTimer()
        {
            TestSaw saw = A.Saw;
            saw.Pause();
            Assert.AreEqual(true, saw.IsPaused);
            Assert.AreEqual(saw.Data.PauseDuration, saw.PauseTimer);
        }

        [UnityTest]
        public IEnumerator Pause_ResumesAfterDuration()
        {
            TestSaw saw = A.Saw;
            saw.Pause();
            Assert.AreEqual(true, saw.IsPaused);
            yield return new WaitForSeconds(saw.Data.PauseDuration);
            yield return null;
            Assert.AreEqual(false, saw.IsPaused);
        }

        [Test]
        public void Resume_Resumes()
        {
            TestSaw saw = A.Saw;
            saw.Pause();
            Assert.AreEqual(true, saw.IsPaused);
            saw.Resume();
            Assert.AreEqual(false, saw.IsPaused);
        }

        [Test]
        public void OnGamePaused_DisablesSaw()
        {
            TestSaw saw = A.Saw;
            saw.OnGamePaused();
            Assert.AreEqual(false, saw.enabled);
        }

        [Test]
        public void OnGameResumed_EnablesSaw()
        {
            TestSaw saw = A.Saw;
            saw.enabled = false;
            saw.OnGameResumed();
            Assert.AreEqual(true, saw.enabled);
        }
    }
}
