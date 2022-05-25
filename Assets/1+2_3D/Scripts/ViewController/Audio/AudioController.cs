using _1_2_3D.Scripts.GameController;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

namespace _1_2_3D.Scripts.ViewController.Audio
{
    public class AudioController : MonoBehaviour
    {
        [SerializeField] private PlayerPreferences _playerAudioPref;
        [SerializeField] private AudioMixerGroup _masterGroup;
        public Slider volumeSlider;

        private void OnEnable()
        {       
            volumeSlider.onValueChanged.AddListener(_playerAudioPref.ChangeVolume);
        }

        private void OnDisable()
        {
            volumeSlider.onValueChanged.RemoveListener(_playerAudioPref.ChangeVolume);
        }

        private void Start()
        {
            if (!PlayerPrefs.HasKey("MasterVolume"))
            {
                PlayerPrefs.SetFloat("MasterVolume", 1);
                _playerAudioPref.LoadAudio();
            }
            else
            {
                _playerAudioPref.LoadAudio();
            }  
        }
    }
}