using UnityEngine;

public static class Settings 
{
    public static bool MusicOn { 
        get 
        {
            return PlayerPrefs.GetInt("MusicOff") == 0;
        }
        set
        {
            PlayerPrefs.SetInt("MusicOff", value ? 0 : 1);
        }
    }
    public static bool SoundOn
    {
        get
        {
            return PlayerPrefs.GetInt("SoundOff") == 0;
        }
        set
        {
            PlayerPrefs.SetInt("SoundOff", value ? 0 : 1);
        }
    }
}
