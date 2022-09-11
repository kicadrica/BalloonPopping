using UnityEngine;
using UnityEngine.UI;

public class SettingsController : MonoBehaviour
{
    [SerializeField] private Toggle _musicToggle;
    [SerializeField] private Toggle _soundToggle;
    
    private void Start()
    {
        _musicToggle.onValueChanged.AddListener(MusicToggleHandle);
        _musicToggle.isOn = Settings.MusicOn;

        _soundToggle.onValueChanged.AddListener(SoundToggleHandle);
        _soundToggle.isOn = Settings.SoundOn;
    }

     private void MusicToggleHandle(bool isOn)
     {
        Settings.MusicOn = isOn;
     }

    private void SoundToggleHandle(bool isOn)
    {
        Settings.SoundOn = isOn;
    }
}
