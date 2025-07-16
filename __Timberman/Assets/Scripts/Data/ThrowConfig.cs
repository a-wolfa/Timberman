using UnityEngine;

namespace Data
{
    [CreateAssetMenu(fileName = "ThrowConfig",  menuName = "Game/Throw Config")]
    public class ThrowConfig : ScriptableObject
    {
        [Header("DoTween Throw Settings")]
        public float doThrowDistance = 20f;
        public float doThrowDuration = 1.5f;
        
        [Header("Rigidbody Throw Settings")]
        public Vector2 rbThrowDirection = new Vector2(1f, 0.8f);
        public float throwForce = 20f;
    }
}