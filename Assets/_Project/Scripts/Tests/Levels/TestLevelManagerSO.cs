using Project.Levels;
using Project.Saving;

namespace Project.Tests.Levels
{
    public class TestLevelManagerSO : LevelManagerSO
    {
        public SaveManagerSO SaveManager { get => _saveManager; set => _saveManager = value; }

        public Level LoadedLevel => _loadedLevel;

        public void SetLevels(TestLevel[] levels)
        {
            int levelCount = levels.Length;
            Levels = new Level[levelCount];

            for (int i = 0; i < levelCount; i++)
            {
                Levels[i] = levels[i];
            }
        }
    }
}
