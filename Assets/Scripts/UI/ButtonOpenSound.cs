using UnityEngine;
using UnityEngine.UI;

public class ButtonOpenSound : MonoBehaviour
{
   
    private void Start()
    {
        GetComponent<Button>().onClick.AddListener(AudioPlay.Instance.PlayOpenSound);
    }

    
}
