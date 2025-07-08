using Systems.Data.Abstractions;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Systems.Data
{
    public class InputData : BaseData
    {
        public InputAction ChopInput { set; get; }
        public override void Clear()
        {
            if (ChopInput == null)
                return;
            
            Debug.Log(ChopInput.name);
            
            ChopInput = null;
        }
    }
}