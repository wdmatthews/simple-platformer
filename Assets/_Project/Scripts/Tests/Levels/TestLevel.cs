using UnityEngine;
using Project.Environment;
using Project.Levels;
using Project.Tests.Characters;
using Project.Tests.Collectibles;
using Project.Tests.Environment;
using Project.Saving;

namespace Project.Tests.Levels
{
    public class TestLevel : Level
    {
        public Transform Entrance { get => _entrance; set => _entrance = value; }
        public TestCollectible Diamond { get => (TestCollectible)_diamond; set => _diamond = value; }
        public TestCollectible Key { get => (TestCollectible)_key; set => _key = value; }
        public TestDoor Door { get => (TestDoor)_door; set => _door = value; }
        public TestPlayer PlayerPrefab { get => (TestPlayer)_playerPrefab; set => _playerPrefab = value; }

        public int Index => _index;
        public SaveDataLevel SaveData => _saveData;
        public TestPlayer Player => (TestPlayer)_player;
        public Transform LastCheckpoint => _lastCheckpoint;

        public void SetToggleBlocks(TestToggleBlock[] toggleBlocks)
        {
            int toggleBlockCount = toggleBlocks.Length;
            _toggleBlocks = new ToggleBlock[toggleBlockCount];

            for (int i = 0; i < toggleBlockCount; i++)
            {
                _toggleBlocks[i] = toggleBlocks[i];
            }
        }

        public void SetButtons(TestButton[] buttons)
        {
            int buttonCount = buttons.Length;
            _buttons = new Button[buttonCount];

            for (int i = 0; i < buttonCount; i++)
            {
                _buttons[i] = buttons[i];
            }
        }
    }
}
