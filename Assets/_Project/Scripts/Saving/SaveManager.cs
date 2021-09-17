using UnityEngine;

namespace Project.Saving
{
    [AddComponentMenu("Project/Saving/Save Manager")]
    [DisallowMultipleComponent]
    public class SaveManager : MonoBehaviour
    {
        [SerializeField] protected SaveManagerSO _saveManager = null;

        protected void Awake()
        {
            _saveManager.Load();
        }
    }
}
