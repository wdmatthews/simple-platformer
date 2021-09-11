using UnityEngine;

namespace Project.Collectibles
{
    [CreateAssetMenu(fileName = "New Collectible", menuName = "Project/Collectibles/Collectible")]
    public class CollectibleSO : ScriptableObject
    {
        public string CollectorLayer = "Character";
    }
}
