using UnityEngine;
using Project.Levels;
using Project.Saving;

namespace Project.UI
{
    [AddComponentMenu("Project/UI/Main Menu")]
    [DisallowMultipleComponent]
    public class MainMenu : MonoBehaviour
    {
        [SerializeField] private Transform _selectableLevelContainer = null;
        [SerializeField] private SelectableLevel _selectableLevelPrefab = null;
        [SerializeField] private LevelManagerSO _levelManager = null;
        [SerializeField] private SaveManagerSO _saveManager = null;

        private void Start()
        {
            int levelCount = _levelManager.Levels.Length;
            int savedLevelCount = _saveManager.SaveData.Levels.Length;
            if (savedLevelCount == 0) _levelManager.FillEmptySave();

            for (int i = 0; i < levelCount; i++)
            {
                SelectableLevel selectableLevel = Instantiate(_selectableLevelPrefab, _selectableLevelContainer);
                selectableLevel.Initialize(i, _levelManager.Levels[i], _saveManager.SaveData.Levels[i]);
            }
        }
    }
}
