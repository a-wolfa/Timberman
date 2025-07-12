using Definitions;
using Systems.Data.Abstractions;
using UnityEngine;

namespace Systems.Data
{
    public class MovementData : BaseData
    {
        public Side CurrentSide = Side.Left;
        
        public override void Clear()
        { }
    }
}
