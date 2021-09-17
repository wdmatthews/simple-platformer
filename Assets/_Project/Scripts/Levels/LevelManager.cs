using UnityEngine;

namespace Project.Levels
{
    [AddComponentMenu("Project/Levels/Level Manager")]
    [DisallowMultipleComponent]
    public class LevelManager : MonoBehaviour
    {
        [SerializeField] protected LevelManagerSO _levelManager = null;

        protected void Start()
        {
            _levelManager.Load();
        }
    }
}
