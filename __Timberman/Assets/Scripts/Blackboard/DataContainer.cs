using System.Collections.Generic;
using Systems.Data.Abstractions;

namespace Blackboard
{
    public class DataContainer
    {
        private readonly BaseData[] _data;

        public DataContainer(BaseData[] data)
        {
            _data = data;
        }

        public void Update()
        {
            foreach (var data in _data)
                data.Clear();
        }
    }
}