using UnityEngine;

public class SpritesDataBase : MonoBehaviour
{
    public Sprite[] BallSprites;
    public static SpritesDataBase Instance; 

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
}
