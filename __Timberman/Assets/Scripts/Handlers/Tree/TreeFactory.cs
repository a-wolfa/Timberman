using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Components;
using Data;
using Definitions;
using Pools;
using Signals;
using Systems;
using UnityEngine;
using UnityEngine.ResourceManagement.AsyncOperations;
using Zenject;

namespace Factories.Tree
{
    public class TreeFactory
    {
        private readonly SignalBus _signalBus;
        private readonly DiContainer _container;

        private ThemeData _theme;
        
        private List<GameObject> _treeSegments;

        public TreeFactory(SignalBus signalBus, DiContainer container)
        {
            _signalBus = signalBus;
            _container = container;
            
            _signalBus.Subscribe<ThemeSelectedSignal>(Create);
        }

        private async void Create(ThemeSelectedSignal signal)
        {
            _theme =  signal.ThemeData;
            
            var handles = new List<AsyncOperationHandle<GameObject>>();

            foreach (var segment in _theme.TreeSegments)
            {
                handles.Add(segment.prefab.LoadAssetAsync());
            }
            
            await Task.WhenAll(handles.Select(h => h.Task));

            if (handles.Any(h => h.Status != AsyncOperationStatus.Succeeded))
            {
                Debug.Log("Failed to create tree segment");
                return;
            }

            var prefabs = new Dictionary<Side, GameObject>();
            if (prefabs == null) throw new ArgumentNullException(nameof(prefabs));

            for (var i = 0; i < handles.Count; i++)
            {
                var side = _theme.TreeSegments[i].Side;
                var prefab = handles[i].Result;
                prefabs[side] = prefab;
            }
            
            InstallTreeBindings(prefabs[Side.Left], prefabs[Side.Right],prefabs[Side.None]);
            _container.Resolve<TreeManagementSystem>().InitTree();
        }

        private void InstallTreeBindings(GameObject leftPrefab, GameObject rightPrefab, GameObject nonePrefab)
        {
            _container.BindMemoryPool<TreeSegment, LeftBranchSegmentPool>()
                .WithInitialSize(10)
                .FromComponentInNewPrefab(leftPrefab)
                .UnderTransformGroup("PooledSegments");

            _container.BindMemoryPool<TreeSegment, RightBranchSegmentPool>()
                .WithInitialSize(10)
                .FromComponentInNewPrefab(rightPrefab)
                .UnderTransformGroup("PooledSegments");

            _container.BindMemoryPool<TreeSegment, NoBranchSegmentPool>()
                .WithInitialSize(10)
                .FromComponentInNewPrefab(nonePrefab)
                .UnderTransformGroup("PooledSegments");
        }
    }
}