using UnityEngine;
using Project.Saving;

namespace Project.Levels
{
    [CreateAssetMenu(fileName = "Level Manager", menuName = "Project/Levels/Level Manager")]
    public class LevelManagerSO : ScriptableObject
    {
        [SerializeField] protected SaveManagerSO _saveManager = null;
        public Level[] Levels = { };

        [System.NonSerialized] public int LevelIndexToLoad = 0;

        [System.NonSerialized] protected Level _loadedLevel = null;

        public void Load()
        {
            if (_saveManager.SaveData.Levels.Length == 0) FillEmptySave();
            Level levelToLoad = Levels[LevelIndexToLoad];
            _loadedLevel = Instantiate(levelToLoad);
            _loadedLevel.name = levelToLoad.name;
            _loadedLevel.Initialize(LevelIndexToLoad, _saveManager.SaveData.Levels[LevelIndexToLoad]);
        }

        public void Unload()
        {
            Destroy(_loadedLevel.gameObject);
            _loadedLevel = null;
        }

        public void FillEmptySave()
        {
            int levelCount = Levels.Length;
            _saveManager.SaveData.Levels = new SaveDataLevel[levelCount];

            for (int i = 0; i < levelCount; i++)
            {
                _saveManager.SaveData.Levels[i] = new SaveDataLevel();
            }
        }

        public void CompleteLevel()
        {
            _loadedLevel.Complete();
            _saveManager.Save();
        }

        public void RestartLevel() => _loadedLevel.Restart();

        public void LoadNextLevel()
        {
            Unload();
            LevelIndexToLoad++;
            Load();
        }
    }
}
