using System.Collections;
using System.Collections.Generic;
using Components;
using Definitions;
using Strategies.ThrowStrategies.Abstractions;
using UnityEngine;

namespace Strategies.ThrowStrategies
{
    public class RbThrow : IThrow
    {
        public void Throw(TreeSegment segment, Side side)
        {
            Rigidbody2D rb = segment.GetComponent<Rigidbody2D>();
            rb.bodyType = RigidbodyType2D.Dynamic;
            rb.gravityScale = 1f;
            
            rb.AddForce(new Vector2(-1 * (int)side, .8f) * 20f, ForceMode2D.Impulse);
            
            segment.DespawnWithDelay();
            Debug.Log("Throw using Rigidbody2D");
        }

        
    }
}