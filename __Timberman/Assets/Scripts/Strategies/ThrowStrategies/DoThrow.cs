using Definitions;
using DG.Tweening;
using Strategies.ThrowStrategies.Abstractions;
using UnityEngine;

namespace Strategies.ThrowStrategies
{
    public class DoThrow : IThrow
    {
        public void Throw(GameObject go, Side side)
        {
            var startPosition = go.transform.position;
            go.transform.DOMove(
                startPosition + new Vector3(-1 * (int)side, 0.8f, 0) * 20, 
                1.5f);
            Debug.Log("Throw using DoTween");
        }
    }
}