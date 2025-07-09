using Systems.Data.Abstractions;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Systems.Data
{
    public class InputData : BaseData
    {
        public int ChopDirection { set; get; }

        public override void Clear()
        {
            ChopDirection = 0;
        }
    }
}