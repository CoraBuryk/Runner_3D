using _1_2_3D.Scripts.ViewController.Audio;
using UnityEngine;

namespace _1_2_3D.Scripts.GameController
{
    public class PlayerPreferences : MonoBehaviour
    {
        [SerializeField] private AudioController _audioController;

        public void LoadAudio()
        {
            _audioController.volumeSlider.value = PlayerPrefs.GetFloat("MasterVolume");
        }

        public void SaveAudio()
        {
           PlayerPrefs.SetFloat("MasterVolume", _audioController.volumeSlider.value);
        }

        public void ChangeVolume(float volume)
        {
            AudioListener.volume = _audioController.volumeSlider.value;
            SaveAudio();
        }

        public void SaveHighScore()
        {
            if (BoneCounterContoller.BoneCounter > BoneCounterContoller.HighScore)
            {
                BoneCounterContoller.HighScore = BoneCounterContoller.BoneCounter;
            }
            PlayerPrefs.SetInt("HighScore", BoneCounterContoller.HighScore);
        }
    }
}
