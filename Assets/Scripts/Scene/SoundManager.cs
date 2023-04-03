using System;
using UnityEngine;

namespace MyFlyBird
{
    public class SoundManager : MonoBehaviour, IEventAssistant
    {
        [SerializeField] private AudioSource _audioSourceLoseGame;
        [SerializeField] private AudioSource _audioSourceClickButton;
        [SerializeField] private AudioSource _audioSourceBiteFruits;

        private void Start()
        {
            IEventAssistant._onSetDamage += SetSoundEndGame;
            IEventAssistant._onSetButton += SetSoundButton;
            IEventAssistant._onSetFruits += SetSoundBite;
        }

        private void SetSoundBite()
        {
            _audioSourceBiteFruits.Play();
        }

        private void SetSoundEndGame()
        {
            _audioSourceLoseGame.Play();
        }

        private void SetSoundButton()
        {
            _audioSourceClickButton.Play();
        }

        private void OnDestroy()
        {
            IEventAssistant._onSetDamage -= SetSoundEndGame;
            IEventAssistant._onSetButton -= SetSoundButton;
            IEventAssistant._onSetFruits -= SetSoundBite;
        }
    }
}
