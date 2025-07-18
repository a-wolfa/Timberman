﻿using Controllers;
using Services;
using Systems;
using TMPro;
using UI.Presenters;
using UI.Views;
using UnityEngine;
using UnityEngine.InputSystem;
using Zenject;
using InputSystem = Systems.InputSystem;

namespace Installers
{
    public class SceneContextInstaller : MonoInstaller
    {
        [Header("Scene Reference")]
        [SerializeField] private InputActionAsset inputactionAsset;
        [SerializeField] private Transform treeParent;
        [SerializeField] private AudioSource audioSource;
        [SerializeField] private TextMeshProUGUI scoreText;

        [Header("Asset References")]
        [SerializeField] private AudioClip chopSoundClip;

        public override void InstallBindings()
        {
            AddControllerBindings();
            AddAssetBindings();
            AddUIBindings();
            AddAudioBindings();
            AddTreeBindings();
        }

        public override void Start()
        {
            Container.Resolve<AudioService>().Init();
            Container.Resolve<InputSystem>().Init();
            Container.Resolve<MovementSystem>().Init();
            Container.Resolve<AnimationSystem>().Init();
        }


        private void AddControllerBindings()
        {
            Container.Bind<GameplayController>()
                .FromComponentInHierarchy()
                .AsSingle();

            Container.Bind<GameStateController>()
                .FromComponentInHierarchy()
                .AsSingle();
        }

        private void AddAssetBindings()
        {
            Container.Bind<InputActionAsset>()
                .FromInstance(inputactionAsset)
                .AsSingle()
                .NonLazy();
        }

        private void AddUIBindings()
        {
            Container.Bind<TextMeshProUGUI>()
                .WithId("ScoreText")
                .FromInstance(scoreText)
                .AsSingle();

            Container.Bind<TimerView>()
                .FromComponentInHierarchy()
                .AsSingle();
            
            Container.BindInterfacesAndSelfTo<ScoreView>()
                .FromComponentInHierarchy()
                .AsSingle();
            Container.BindInterfacesAndSelfTo<ScorePresenter>()
                .AsSingle();

            Container.Bind<TapGroupView>()
                .FromComponentInHierarchy()
                .AsSingle();

            Container.Bind<ScoreService>()
                .AsSingle();
        }

        private void AddAudioBindings()
        {
            Container.Bind<AudioSource>()
                .WithId("ChopAudioSource")
                .FromInstance(audioSource)
                .AsSingle();

            Container.Bind<AudioClip>()
                .WithId("ChopSoundClip")
                .FromInstance(chopSoundClip)
                .AsSingle();

            Container.BindInterfacesAndSelfTo<AudioService>()
                .AsSingle();
        }

        private void AddTreeBindings()
        {
            Container.Bind<Transform>()
                .WithId("Root")
                .FromInstance(treeParent)
                .AsSingle();
        }
    }
}