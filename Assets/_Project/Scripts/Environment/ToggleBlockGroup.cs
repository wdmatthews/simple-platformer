using UnityEngine;

namespace Project.Environment
{
    [AddComponentMenu("Project/Environment/Toggle Block Group")]
    [DisallowMultipleComponent]
    public class ToggleBlockGroup : MonoBehaviour
    {
        [SerializeField] protected ToggleBlock[] _blocks = { };

        protected int _blockCount = 0;
        protected bool _isOn = true;

        protected void Awake()
        {
            _blockCount = _blocks.Length;
        }

        public void Toggle()
        {
            _isOn = !_isOn;

            for (int i = 0; i < _blockCount; i++)
            {
                _blocks[i].Toggle();
            }
        }
    }
}
