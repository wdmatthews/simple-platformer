using UnityEngine;

namespace Project.Environment
{
    [CreateAssetMenu(fileName = "New Hazard", menuName = "Project/Environment/Hazard")]
    public class HazardSO : ScriptableObject
    {
        public float Damage = 1;
    }
}
