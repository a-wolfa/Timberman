using Definitions;
using UnityEngine;

namespace Components
{
    public class TreeSegment : MonoBehaviour
    {
        [SerializeField] private Side branchSide;
        public Side BranchSide { get => branchSide; set => branchSide = value; }
    }
}
