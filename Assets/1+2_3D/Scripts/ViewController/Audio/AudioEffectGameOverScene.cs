using UnityEngine;

namespace _1_2_3D.Scripts.ViewController.Audio
{
    public class AudioEffectGameOverScene : MonoBehaviour
    {
        [SerializeField] private AudioSource _bestScore;

        public void PlayOnBestScore()
        {
            _bestScore.Play();
        }
    }
}
