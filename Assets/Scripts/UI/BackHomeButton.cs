using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class BackHomeButton : MonoBehaviour
{
    private void Start()
    {
        GetComponent<Button>().onClick.AddListener(BackToMenu);
    }

    private void BackToMenu()
    {
        SceneManager.LoadScene("Menu");
    }
}
