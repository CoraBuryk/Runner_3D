using UnityEngine;

namespace _1_2_3D.Scripts.ViewController.Audio
{
    public class AudioEffectsMainScene : MonoBehaviour
    {
        [SerializeField] private AudioSource _answerRight;
        [SerializeField] private AudioSource _answerWrong;
        [SerializeField] private AudioSource _obstacle;
        [SerializeField] private AudioSource _bone;
        [SerializeField] private AudioSource _jump;

        public void PlayAnswerRight()
        {
            _answerRight.Play();
        }

        public void PlayAnswerWrong()
        {
            _answerWrong.Play();
        }

        public void PlayObstacle()
        {
            _obstacle.Play();
        }

        public void PlayBone()
        {
            _bone.Play();
        }

        public void PlayJump()
        {
            _jump.Play();
        }
    }
}
