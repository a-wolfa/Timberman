using DG.Tweening;
using Strategies.ThrowStrategies.Abstractions;
using UnityEngine;

namespace Strategies.ThrowStrategies
{
    public class DoThrow : IThrow
    {
        public void Throw(GameObject go)
        {
            go.transform.DOMove(go.transform.position + (new Vector3(1, .8f, 0) * 20), 1.5f);
            Debug.Log("Throw using DoTween");
        }
    }
}