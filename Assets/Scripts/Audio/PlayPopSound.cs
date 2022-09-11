using UnityEngine;

public class PlayPopSound : MonoBehaviour
{
    private void Start()
    {
        BallController.OnBallCollected += PopSound;
    }

    private void OnDestroy()
    {
        BallController.OnBallCollected -= PopSound;
    }

    private void PopSound(BallController obj)
    {
        if (Settings.SoundOn)
        {
            AudioPlay.Instance.PlayPopSound();
        }
    }

}
