using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;
public class MainButtonsAnimation : MonoBehaviour
{
    [SerializeField] private Transform SettingsOption;
    [SerializeField] private Button SettingsButton;
    [SerializeField] private Button CloseButton;

    void Start()
    {
        transform.DOMoveY(0, 1.5f).SetEase(Ease.InOutBack);
        SettingsButton.onClick.AddListener(OpenSettings);
        SettingsOption.DOMoveX(15, 0f).SetEase(Ease.OutCirc);

        CloseButton.onClick.AddListener(CloseSettings);
    }

    private void OpenSettings()
    {
        transform.DOMoveY(15, 1f).SetEase(Ease.OutBack);
        SettingsOption.DOMoveX(0, 1f).SetEase(Ease.Flash);
    }

    private void CloseSettings()
    {
        SettingsOption.DOMoveX(15, 1f).SetEase(Ease.InSine);
        transform.DOMoveY(0, 1.5f).SetEase(Ease.InOutBack);
    }

}
