using Definitions;
using Strategies.ThrowStrategies.Abstractions;
using UnityEngine;

namespace Strategies.ThrowStrategies
{
    public class RbThrow : IThrow
    {
        public void Throw(GameObject go, Side side)
        {
            Rigidbody2D rb = go.GetComponent<Rigidbody2D>();
            rb.bodyType = RigidbodyType2D.Dynamic;
            rb.gravityScale = 1f;
            
            rb.AddForce(new Vector2(-1 * (int)side, .8f) * 20f, ForceMode2D.Impulse);
            
            Debug.Log("Throw using Rigidbody2D");
        }
    }
}