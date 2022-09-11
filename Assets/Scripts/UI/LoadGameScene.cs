using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadGameScene : MonoBehaviour
{
    private void Start()
    {
        GetComponent<Button>().onClick.AddListener(StartGame);    
    }

    private void StartGame()
    {
        SceneManager.LoadScene("Game");
    }

}
