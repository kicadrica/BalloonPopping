using UnityEngine;
using UnityEngine.UI;

public class Background : MonoBehaviour
{
    [SerializeField] private Sprite[] BackgroundImages;
    private Image _image;

    private void Start()
    {
        _image = GetComponent<Image>();
        ChangeBackGround();
    }

    private void ChangeBackGround()
    {
        _image.sprite = BackgroundImages[Random.Range(0, BackgroundImages.Length)];
    }
}
