using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Project.Levels;
using Project.Saving;

namespace Project.UI
{
    [AddComponentMenu("Project/UI/Selectable Level")]
    [DisallowMultipleComponent]
    public class SelectableLevel : MonoBehaviour
    {
        [SerializeField] private Image _checkmarkIcon = null;
        [SerializeField] private Image _diamondIcon = null;
        [SerializeField] private TextMeshProUGUI _label = null;
        [SerializeField] private Button _playButton = null;
        [SerializeField] private LevelManagerSO _levelManager = null;
        [SerializeField] private SaveManagerSO _saveManager = null;
        [SerializeField] private SceneManagerSO _sceneManager = null;

        private int _index = 0;

        public void Initialize(int index, Level level, SaveDataLevel saveData)
        {
            _index = index;
            _checkmarkIcon.gameObject.SetActive(saveData.WasCompleted);
            if (saveData.DiamondWasCollected) _diamondIcon.sprite = level.DiamondSprite;
            _label.text = level.name;
            _playButton.interactable = saveData.WasCompleted || index == 0
                || (index > 0 && _saveManager.SaveData.Levels[index - 1].WasCompleted);
        }

        public void Play()
        {
            _levelManager.LevelIndexToLoad = _index;
            _sceneManager.LoadScene("Level");
        }
    }
}
