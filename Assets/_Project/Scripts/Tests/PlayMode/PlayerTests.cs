using System.Collections;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.TestTools;
using Project.Tests.Builders;
using Project.Tests.Characters;

namespace Project.Tests.PlayMode
{
    public class PlayerTests : InputTestFixture
    {
        private static PlayerInput GetPlayerInput(TestPlayer player)
        {
            PlayerInput playerInput = player.gameObject.GetComponent<PlayerInput>();
            playerInput.actions = ScriptableObject.CreateInstance<InputActionAsset>();
            playerInput.actions.AddActionMap("Gameplay");
            playerInput.SwitchCurrentActionMap("Gameplay");
            PlayerInput.Instantiate(player);
            return playerInput;
        }

        private static void AddMoveAction(PlayerInput playerInput, TestPlayer player)
        {
            InputAction action = playerInput.currentActionMap.AddAction("Move", InputActionType.Value);
            action
                .AddCompositeBinding("Axis")
                .With("Negative", "<Keyboard>/a")
                .With("Positive", "<Keyboard>/d");
            action.Enable();
            action.performed += player.Move;
        }

        private static void AddJumpAction(PlayerInput playerInput, TestPlayer player)
        {
            InputAction action = playerInput.currentActionMap.AddAction("Jump", InputActionType.Button);
            action.AddBinding("<Keyboard>/w");
            action.Enable();
            action.performed += player.Jump;
        }

        [Test]
        public void MoveLeft_SetsMoveDirection_Negative()
        {
            Keyboard keyboard = InputSystem.AddDevice<Keyboard>();
            TestPlayer player = A.Player;
            PlayerInput playerInput = GetPlayerInput(player);
            AddMoveAction(playerInput, player);
            Press(keyboard.aKey);
            Assert.AreEqual(-1, player.MoveDirection);
        }

        [Test]
        public void MoveRight_SetsMoveDirection_Positive()
        {
            Keyboard keyboard = InputSystem.AddDevice<Keyboard>();
            TestPlayer player = A.Player;
            PlayerInput playerInput = GetPlayerInput(player);
            AddMoveAction(playerInput, player);
            Press(keyboard.dKey);
            Assert.AreEqual(1, player.MoveDirection);
        }

        [UnityTest]
        public IEnumerator Jump_SetsYVelocity_JumpSpeed()
        {
            Keyboard keyboard = InputSystem.AddDevice<Keyboard>();
            TestPlayer player = A.Player;
            PlayerInput playerInput = GetPlayerInput(player);
            AddJumpAction(playerInput, player);
            Press(keyboard.wKey);
            yield return new WaitForFixedUpdate();
            Assert.AreEqual(player.Data.JumpSpeed, player.Rigidbody.velocity.y);
            yield return null;
        }
    }
}
