using UnityEngine;

public class GameWin : MonoBehaviour
{
    [SerializeField] private GameObject WinInfo; 
    
    public static bool IsGameWin; 
    private void Start()
    {
        IsGameWin = false; 
    }
    
    private void Update()
    {
        CheckWinGame(); 
    }

    private void CheckWinGame() 
    {
        if (GameOver.IsGameOver) return;
        if (PointsController.QuestColorsCount == 0) 
        {
            WinInfo.SetActive(true); 
            IsGameWin = true; 
        }
    }
}
