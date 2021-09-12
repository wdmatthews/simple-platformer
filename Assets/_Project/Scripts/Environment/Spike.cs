using UnityEngine;

namespace Project.Environment
{
    [AddComponentMenu("Project/Environment/Spike")]
    [DisallowMultipleComponent]
    [RequireComponent(typeof(BoxCollider2D))]
    public class Spike : Hazard { }
}
