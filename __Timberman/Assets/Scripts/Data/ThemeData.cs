using System.Collections.Generic;
using System.Linq;
using Components;
using Definitions;
using Helper;
using UnityEngine;
using UnityEngine.AddressableAssets;

namespace Data
{
    [CreateAssetMenu(fileName = "NewThemeData", menuName = "Game/Theme Data")]
    public class ThemeData : ScriptableObject
    {
        public Theme theme;

        public GoPrefabMapper Forest;
        public GoPrefabMapper Player;
        public List<SegmentPrefabMapping> TreeSegments;
        
        
        public AssetReferenceGameObject GetPrefabReference(Side side)
        {
            return TreeSegments.FirstOrDefault(segment => segment.Side == side)?.prefab;
        }

        public AssetReferenceGameObject GetPrefabReference(BasePrefabMapper baseMapper)
        {
            return baseMapper.prefab;
        }
    }
}
