using UnityEngine;

public class AudioEffects : MonoBehaviour
{
    [SerializeField] private AudioSource _answerRight;
    [SerializeField] private AudioSource _answerWrong;
    [SerializeField] private AudioSource _obstacle;
    [SerializeField] private AudioSource _bone;
    [SerializeField] private AudioSource _example;
    [SerializeField] private AudioSource _main;
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

    public void PlayExample()
    {
        _example.Play();
    }

    public void PlayExampleOff()
    {
        _example.Stop();
    }

    public void PlayMain()
    {
        _main.Play();
    }

    public void PlayMainOff()
    {
        _main.Stop();
    }

    public void PlayJump()
    {
        _jump.Play();
    }
}
