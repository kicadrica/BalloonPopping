using UnityEngine;

public class AudioPlay : MonoBehaviour
{
    [SerializeField] private AudioSource _openButtonSource;
    [SerializeField] private AudioSource _closeButtonSource;
    [SerializeField] private AudioSource _popBallSource;

    public static AudioPlay Instance;

    
    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

   public void PlayOpenSound()
    {
        if(Settings.SoundOn)
             _openButtonSource.Play();
    }

    public void PlayCloseSound()
    {
        if (Settings.SoundOn)
            _closeButtonSource.Play();
    }

    public void PlayPopSound()
    {
        if (Settings.SoundOn)
            _popBallSource.Play();
    }
}
