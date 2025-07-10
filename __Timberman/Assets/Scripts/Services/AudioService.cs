using System;
using UnityEngine;
using Zenject;
using Signals;

namespace Services
{
    public class AudioService : IInitializable, IDisposable
    {
        private AudioSource _audioSource;
        private AudioClip _chopSound;
        private SegmentChoppedSignal _segmentChoppedSignal;

        [Inject]
        public void Construct(SegmentChoppedSignal segmentChoppedSignal, 
                            [Inject(Id = "ChopAudioSource")] AudioSource audioSource, 
                            [Inject(Id = "ChopSound")] AudioClip chopSound)
        {
            _segmentChoppedSignal = segmentChoppedSignal;
            _audioSource = audioSource;
            _chopSound = chopSound;
        }

        public void Initialize()
        {
            _segmentChoppedSignal.Subscribe(OnSegmentChopped);
        }

        public void Dispose()
        {
            _segmentChoppedSignal?.Unsubscribe(OnSegmentChopped);
            _audioSource = null;
        }

        private void OnSegmentChopped(int points)
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
