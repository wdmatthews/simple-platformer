using Project.Environment;

namespace Project.Tests.Environment
{
    public class TestToggleBlockGroup : ToggleBlockGroup
    {
        public ToggleBlock[] Blocks
        {
            get => _blocks;
            set
            {
                _blocks = value;
                _blockCount = value.Length;
            }
        }

        public int BlockCount => _blockCount;
        public bool IsOn => _isOn;
    }
}
