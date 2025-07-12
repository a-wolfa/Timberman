using DG.Tweening;
using UnityEngine;

namespace Extensions
{
    public static class ThrowExtension
    {
        public static void Throw(this GameObject gameObject)
        {
            gameObject.transform.DOMove(gameObject.transform.position + (new Vector3(1, .8f, 0) * 20), 1.5f);
        }
    }
}