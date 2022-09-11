using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameOver : MonoBehaviour
{
    public UnityEvent OnGameOver;
    public static bool IsGameOver;

    private float _gameOverLine = -3.4f;
    private List<BallController> _ballsUnderLine = new List<BallController>();

    private void Start()
    {
        IsGameOver = false;
        StartCoroutine(CheckBallsUnderLine());
    }
    
    private IEnumerator CheckBallsUnderLine()
    {
        yield return new WaitForSeconds(5f);
        while (true)
        {
            yield return new WaitForSeconds(5f);
            if (GameWin.IsGameWin) yield break;
            foreach (var ball in BallController.BallsList)
            {
                if (ball.transform.position.y < _gameOverLine)
                {
                    if (_ballsUnderLine.Contains(ball))
                    {
                        IsGameOver = true;
                        OnGameOver?.Invoke();
                        yield break;
                    }
                    
                }
            }

            _ballsUnderLine.Clear();

            foreach (var ball in BallController.BallsList)
            {
                if (ball.transform.position.y < _gameOverLine)
                {
                    _ballsUnderLine.Add(ball);
                }
            }
        }
    }
}
