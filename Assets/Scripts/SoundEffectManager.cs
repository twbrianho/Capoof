using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class SoundEffectManager : MonoBehaviour
{
    public AudioSource audioSource;

    public AudioClip pop1Sound;
    public AudioClip pop2Sound;
    public AudioClip pop3Sound;

    public AudioClip wah1Sound;
    public AudioClip wah2Sound;
    public AudioClip wah3Sound;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayCapooLaunchSound()
    {
        int randomSound = Random.Range(1, 4);
        switch (randomSound) {
            case 1:
                audioSource.PlayOneShot(wah1Sound, 0.5f);
                break;
            case 2:
                audioSource.PlayOneShot(wah2Sound, 0.5f);
                break;
            case 3:
                audioSource.PlayOneShot(wah3Sound, 0.5f);
                break;
        }
    }

    public void PlayCapooMergeSound()
    {
        int randomSound = Random.Range(1, 4);
        switch (randomSound) {
            case 1:
                audioSource.PlayOneShot(pop1Sound);
                break;
            case 2:
                audioSource.PlayOneShot(pop2Sound);
                break;
            case 3:
                audioSource.PlayOneShot(pop3Sound);
                break;
        }
    }
}
