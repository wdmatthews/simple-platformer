using UnityEngine;
using Project.Saving;
using Project.Tests.Levels;

namespace Project.Tests.Builders
{
    public class LevelManagerSOBuilder
    {
        private SaveManagerSO _saveManager = null;
        private TestLevel[] _levels = null;

        public LevelManagerSOBuilder WithSaveManager(SaveManagerSO saveManager)
        {
            _saveManager = saveManager;
            return this;
        }

        public LevelManagerSOBuilder WithLevels(TestLevel[] levels)
        {
            _levels = levels;
            return this;
        }

        public TestLevelManagerSO Build()
        {
            TestLevelManagerSO manager = ScriptableObject.CreateInstance<TestLevelManagerSO>();
            manager.SaveManager = _saveManager ? _saveManager : A.SaveManagerSO;
            if (_levels != null) manager.SetLevels(_levels);
            return manager;
        }

        public static implicit operator TestLevelManagerSO(LevelManagerSOBuilder builder) => builder.Build();
    }
}
