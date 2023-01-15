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
    public AudioClip wah4Sound;
    public AudioClip wah5Sound;
    public AudioClip wah6Sound;
    public AudioClip wah7Sound;
    public AudioClip wah8Sound;
    public AudioClip wah9Sound;

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
        int randomSound = Random.Range(1, 10);
        switch (randomSound) {
            case 1:
                audioSource.PlayOneShot(wah1Sound);
                break;
            case 2:
                audioSource.PlayOneShot(wah2Sound);
                break;
            case 3:
                audioSource.PlayOneShot(wah3Sound);
                break;
            case 4:
                audioSource.PlayOneShot(wah4Sound);
                break;
            case 5:
                audioSource.PlayOneShot(wah5Sound);
                break;
            case 6:
                audioSource.PlayOneShot(wah6Sound);
                break;
            case 7:
                audioSource.PlayOneShot(wah7Sound);
                break;
            case 8:
                audioSource.PlayOneShot(wah8Sound);
                break;
            case 9:
                audioSource.PlayOneShot(wah9Sound);
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
