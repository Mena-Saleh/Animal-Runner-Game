using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioSource musicSource;
    public AudioSource SFXSource;
    // Start is called before the first frame update

    public AudioClip background;
    public AudioClip collision;
    public AudioClip jumping;
    public AudioClip coinCollect;


    void Start()
    {
        musicSource.clip = background;
        musicSource.Play();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void PlaySFX(AudioClip Clip)
    {
        SFXSource.PlayOneShot(Clip);
    }
}
