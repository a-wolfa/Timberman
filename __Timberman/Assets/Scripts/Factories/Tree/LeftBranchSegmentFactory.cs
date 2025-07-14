using Factories.Tree.Abstractions;
using Pools;
using Zenject;

namespace Factories.Tree
{
    public class LeftBranchSegmentFactory : BaseSegmentFactory<LeftBranchSegmentPool>
    {
        public LeftBranchSegmentFactory(DiContainer container)
            : base(container) { }
    }
}