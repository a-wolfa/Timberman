using Factories.Tree.Abstractions;
using Pools;
using Zenject;

namespace Factories.Tree
{
    public class NoBranchSegmentFactory : BaseSegmentFactory<NoBranchSegmentPool>
    {
        public NoBranchSegmentFactory(DiContainer container)
            : base(container) { }
    }
}