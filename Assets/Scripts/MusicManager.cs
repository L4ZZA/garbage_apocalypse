using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour
{
    private static MusicManager instance;

    static float maxMolume = 0.5f;
    static float maxSfxVolume = 1f;

    public static float master = maxMolume;
    public static float volume = maxMolume;
    public static float sfxVolume = maxSfxVolume;
    
    //public static bool master = true;
    //public static bool sfx    = true;

    // Start is called before the first frame update
    void Start()
    {
        if (!instance)
        {
            instance = this;
            DontDestroyOnLoad(instance);
        }
        else
        {
            Destroy(gameObject);
        }
    }


    public static void ToggleMasterVolume()
    {

    }


}
