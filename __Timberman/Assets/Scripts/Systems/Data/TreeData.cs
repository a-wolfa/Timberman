using System.Collections.Generic;
using Components;
using Systems.Data.Abstractions;
using UnityEngine;

namespace Systems.Data
{
    public class TreeData : BaseData
    {
        public bool ShouldMoveTree { get; set; }
        public List<TreeSegment> Segments;

        public TreeData(List<TreeSegment> segments)
        {
            Segments = segments;
        }
        
        public override void Clear()
        {
            ShouldMoveTree = false;
        }
        
        
    }
}
