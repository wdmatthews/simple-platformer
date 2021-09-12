using UnityEngine;
using Project.Events;

namespace Project.Characters
{
    [CreateAssetMenu(fileName = "New Character Float Event", menuName = "Project/Characters/Character Float Event")]
    public class CharacterFloatEventChannelSO : TwoTypeEventChannelSO<Character, float> { }
}
