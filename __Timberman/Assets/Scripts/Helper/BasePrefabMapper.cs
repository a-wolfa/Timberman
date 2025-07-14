using System;
using UnityEngine.AddressableAssets;

namespace Helper
{
    [Serializable]
    public abstract class BasePrefabMapper
    {
        public AssetReferenceGameObject prefab;
    }
}