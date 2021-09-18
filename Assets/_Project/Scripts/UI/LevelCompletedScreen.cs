using UnityEngine;
using TMPro;
using Project.Events;
using Project.Levels;

namespace Project.UI
{
    [AddComponentMenu("Projects/UI/Level Completed Screen")]
    [DisallowMultipleComponent]
    public class LevelCompletedScreen : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _headerText = null;
        [SerializeField] private TextMeshProUGUI _diamondStatusText = null;
        [SerializeField] private Transform _nextButton = null;
        [SerializeField] private Transform _creditsButton = null;
        [SerializeField] private LevelManagerSO _levelManager = null;
        [SerializeField] private BoolEventChannelSO _onLevelCompletedChannel = null;

        private void Awake()
        {
            if (_onLevelCompletedChannel) _onLevelCompletedChannel.OnRaised += Show;
            gameObject.SetActive(false);
        }

        private void OnDestroy()
        {
            if (_onLevelCompletedChannel) _onLevelCompletedChannel.OnRaised -= Show;
        }

        public void Show(bool diamondWasCollected)
        {
            int levelIndex = _levelManager.LevelIndexToLoad;
            bool isLastLevel = levelIndex == _levelManager.Levels.Length - 1;
            _headerText.text = $"Level {levelIndex + 1} Completed";
            _diamondStatusText.text = $"Diamond Was{(diamondWasCollected ? " " : " Not ")}Collected";
            _nextButton.gameObject.SetActive(!isLastLevel);
            _creditsButton.gameObject.SetActive(isLastLevel);
            gameObject.SetActive(true);
        }
    }
}
