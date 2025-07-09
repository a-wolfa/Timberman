using UnityEngine;

namespace Components
{
    public class TreeSegment : MonoBehaviour
    {
        [SerializeField] private bool hasLeftBranch;
        [SerializeField] private bool hasRightBranch;
        
        public bool HasLeftBranch => hasLeftBranch;
        public bool HasRightBranch => hasRightBranch;
        
        public void SetBranches(bool left, bool right)
        {
            hasLeftBranch = left;
            hasRightBranch = right;
        }
    }
}
