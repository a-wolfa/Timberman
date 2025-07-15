using UnityEngine;

namespace AnimationEvents
{
    public class SmokeAnimationEvents : MonoBehaviour
    {
        public void DeactivateSelf()
        {
            gameObject.SetActive(false);
        }
    }
}
