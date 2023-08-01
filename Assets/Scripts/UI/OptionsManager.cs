using UnityEngine.Audio;
using UnityEngine;

namespace MyFlyBird
{
    public class OptionsManager : MonoBehaviour
    {
        [SerializeField] private AudioMixerGroup _musicChannel;
        [SerializeField] private AudioMixerGroup _effectsChannel;

        public void ChangeVolumeMusic(float volume)
        {
            _musicChannel.audioMixer.SetFloat("MusicVolume", Mathf.Lerp(-80, 0, volume));
        }

        public void ChangeVolumeEffects(float volume)
        {
            _effectsChannel.audioMixer.SetFloat("EffectsVolume", Mathf.Lerp(-80, 0, volume));
        }
    }
}