using UnityEngine;

public class MusicController : MonoBehaviour
{
    private AudioSource _source;
    private void Start()
    {
        _source = GetComponent<AudioSource>();
    }

    private void Update()
    {
        _source.enabled = Settings.MusicOn;
    }
}
