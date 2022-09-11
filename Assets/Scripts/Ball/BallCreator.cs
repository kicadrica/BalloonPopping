using UnityEngine;

public class BallCreator : MonoBehaviour
{
    [SerializeField] private BallController BallPrefab; 
    [SerializeField] private int BallCount = 10; 

    private void Update()
    {
        CreateBall(); 
    }

    private void CreateBall() //Метод отвечающий за создание шариков.
    {
        if (BallController.BallsList.Count < BallCount) 
        {
            var newBall = Instantiate(BallPrefab,transform); 
            newBall.PlaceRandom(); 
        }
    }
}
