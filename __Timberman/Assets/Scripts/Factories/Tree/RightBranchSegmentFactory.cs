using Factories.Tree.Abstractions;
using Pools;
using Zenject;

namespace Factories.Tree
{
    public class RightBranchSegmentFactory : BaseSegmentFactory<RightBranchSegmentPool>
    {
        public RightBranchSegmentFactory(DiContainer container)
            : base(container) { }
    }
}