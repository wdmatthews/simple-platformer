using NUnit.Framework;
using UnityEngine;
using UnityEngine.InputSystem;
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
            InputAction moveAction = playerInput.currentActionMap.AddAction("Move", InputActionType.Value);
            moveAction
                .AddCompositeBinding("Axis")
                .With("Negative", "<Keyboard>/a")
                .With("Positive", "<Keyboard>/d");
            moveAction.Enable();
            moveAction.performed += player.Move;
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
    }
}
