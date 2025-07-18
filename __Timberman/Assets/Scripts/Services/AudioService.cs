using System;
using UnityEngine;
using Zenject;
using Signals;

namespace Services
{
    public class AudioService
    {
        private AudioSource _audioSource;
        private AudioClip _chopSound;
        private SignalBus _signalBus;

        [Inject]
        public void Construct(SignalBus signalBus, 
                            [Inject(Id = "ChopAudioSource")] AudioSource audioSource, 
                            [Inject(Id = "ChopSoundClip")] AudioClip chopSound)
        {
            _signalBus = signalBus;
            _audioSource = audioSource;
            _chopSound = chopSound;
        }

        public void Init()
        {
            _signalBus.Subscribe<SegmentChoppedSignal>(OnSegmentChopped);
        }

        private void OnSegmentChopped(SegmentChoppedSignal segmentChoppedSignal)
        {
            if (_audioSource != null && _chopSound != null)
            {
                _audioSource.PlayOneShot(_chopSound);
            }
        }

        public void PlayChopSound()
        {
            if (_audioSource != null && _chopSound != null)
            {
                _audioSource.PlayOneShot(_chopSound);
            }
        }
    }
}
