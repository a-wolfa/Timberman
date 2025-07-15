using UnityEngine;

namespace AnimationEvents
{
    public class DeactivationOnAnimationEnd : MonoBehaviour
    {
        public void DeactivateGameObject()
        {
            gameObject.SetActive(false);
        }
    }
}
