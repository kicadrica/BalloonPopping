using UnityEngine;
using UnityEngine.UI;

public class ButtonCloseSound : MonoBehaviour
{
    private void Start()
    {
        GetComponent<Button>().onClick.AddListener(AudioPlay.Instance.PlayCloseSound);
    }
}
