using UnityEngine;

namespace MyFlyBird
{
    public class SoundManager : MonoBehaviour, IEventAssistant
    {
        [SerializeField] private AudioSource _audioSourceLoseGame;
        [SerializeField] private AudioSource _audioSourceClickButton;

        private void Start()
        {
            IEventAssistant._onSetDamage += SetSoundEndGame;
            IEventAssistant._onSetButton += SetSoundButton;
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
        }
    }
}
