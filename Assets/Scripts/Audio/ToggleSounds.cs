using UnityEngine;
using UnityEngine.UI;

public class ToggleSounds : MonoBehaviour
{
    
    void Start()
    {
        GetComponent<Toggle>().onValueChanged.AddListener(ToggleHandle);
    }

    
    private void ToggleHandle (bool isOn)
    {
        if (isOn)
        {
            AudioPlay.Instance.PlayOpenSound();
        }
        else
        {
            AudioPlay.Instance.PlayCloseSound();
        }
    }
}
