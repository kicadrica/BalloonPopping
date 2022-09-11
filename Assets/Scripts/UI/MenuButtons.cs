using UnityEngine;

public class MenuButtons : MonoBehaviour
{
    [SerializeField] private GameObject _allMenuButtons;
 
    public void OpenAllMenuButtons()
    {
        _allMenuButtons.SetActive(!_allMenuButtons.activeSelf);
    }

    
}
