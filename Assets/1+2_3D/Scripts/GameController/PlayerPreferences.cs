using _1_2_3D.Scripts.ViewController.Audio;
using UnityEngine;

namespace _1_2_3D.Scripts.GameController
{
    public class PlayerPreferences : MonoBehaviour
    {
        [SerializeField] private AudioController _audioController;
        //[SerializeField] private BestScoreMenu _bestScoreMenu;
        [SerializeField] private BoneCounterContoller _boneCounterController;

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

        public void LoadScore()
        {
            if (PlayerPrefs.HasKey("HighScore")) ;
                //_bestScoreMenu._bestScore.text = "Score:" + PlayerPrefs.GetInt("HighScore");
        }

        public void SaveHighScore()
        {
            if (_boneCounterController.BoneCounter > _boneCounterController.HighScore)
            {
                _boneCounterController.HighScore = _boneCounterController.BoneCounter;
            }
            PlayerPrefs.SetInt("HighScore", _boneCounterController.HighScore);
        }
    }
}
