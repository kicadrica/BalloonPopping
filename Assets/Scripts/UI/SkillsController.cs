using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class SkillsController : MonoBehaviour
{
    [SerializeField] private GameObject AllSkills;
    [SerializeField] private Image _blockerImage;
    [SerializeField] private Transform SkillsButton;

    private float _startingTimer = 60f;
    private float _timer;
   
    private void Start()
    {
        _timer = _startingTimer;
    }
    private void Update()
    {
        if (_timer > 0)
        {
            _timer -= Time.deltaTime;
            _blockerImage.fillAmount = _timer / _startingTimer;
        }
        if (_timer < 0)
        {
            _timer = 0;
            SkillsButton.DOScale(0.9f, 0.3f).SetLoops(4, LoopType.Yoyo);
        }
  
        _blockerImage.gameObject.SetActive(_timer != 0);

    }

    public void OpenAllSkills()
    {
        AllSkills.SetActive(!AllSkills.activeSelf);
    }

    public void PopAllByColor()
    {
        
        if (_timer == 0)
        {
            int randomBallsColors = Random.Range(0, SpritesDataBase.Instance.BallSprites.Length);

            foreach (var ball in BallController.BallsList)
            {
                if (ball.SpriteIndex == randomBallsColors)
                {
                    ball.Pop();
                }
            }
            AllSkills.SetActive(false);
            _timer = _startingTimer;
        }
    }

    public void ShuffleAllBalls()
    {
        if (_timer == 0)
        {
            foreach (var ball in BallController.BallsList)
            {
                ball.PlaceRandom();

            }
            AllSkills.SetActive(false);
            _timer = _startingTimer;
        }
    }

    public void PopSingleBalls()
    {
        if (_timer == 0)
        {
            foreach (var ball in BallController.BallsList)
            {
                if(ball.Neighbors.Count == 0)
                {
                    ball.Pop();
                }

            }
            AllSkills.SetActive(false);
            _timer = _startingTimer;
        }
    }



}
