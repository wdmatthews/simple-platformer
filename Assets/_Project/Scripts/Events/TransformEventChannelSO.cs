using UnityEngine;

namespace Project.Events
{
    [CreateAssetMenu(fileName = "New Transform Event", menuName = "Project/Events/Transform Event")]
    public class TransformEventChannelSO : OneTypeEventChannelSO<Transform> { }
}
