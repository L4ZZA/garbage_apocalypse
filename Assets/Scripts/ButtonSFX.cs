using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonSFX : MonoBehaviour
{
    AudioSource source;
    public AudioClip hoverSFX;
    public AudioClip clickSFX;

    // Start is called before the first frame update
    void Start()
    {
        source = GetComponent<AudioSource>();
    }
    public void HoverSound()
    {
        if (hoverSFX)
            source.PlayOneShot(hoverSFX);
    }

    public void ClickSound()
    {
        if (clickSFX)
            source.PlayOneShot(clickSFX);
    }
}
