using Systems.Data.Abstractions;
using UnityEngine;

namespace Systems.Data
{
    public class TreeData : BaseData
    {
        public bool ShouldMoveTree { get; set; }
        
        public override void Clear()
        {
            ShouldMoveTree = false;
        }
    }
}
