using UnityEngine;
using UnityEngine.SceneManagement;

namespace Project.Levels
{
    [CreateAssetMenu(fileName = "Scene Manager", menuName = "Project/Levels/Scene Manager")]
    public class SceneManagerSO : ScriptableObject
    {
        public void LoadScene(string sceneName) => SceneManager.LoadScene(sceneName);
    }
}
