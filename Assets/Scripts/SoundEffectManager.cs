using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(AudioSource))]
public class SoundEffectManager : MonoBehaviour
{
    public float MAX_VOLUME = 1.0f;

    [SerializeField] public Slider sfxSlider;

    public AudioSource sfxSource;
    [SerializeField] public AudioClip[] popClips;
    [SerializeField] public AudioClip[] wahClips;

    // Start is called before the first frame update
    void Start()
    {
        sfxSource = GetComponent<AudioSource>();
        
        // Load the volume from the previous session
        if (PlayerPrefs.HasKey("SfxVolume"))
        {
            LoadVolume();
        }
        else
        {
            SetVolume();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayCapooLaunchSound()
    {
        // Play a random wah clip
        sfxSource.PlayOneShot(wahClips[Random.Range(0, wahClips.Length)]);
    }

    public void PlayCapooMergeSound()
    {
        // Play a random pop clip
        sfxSource.PlayOneShot(popClips[Random.Range(0, popClips.Length)]);
    }

    public void SetVolume()
    {
        sfxSource.volume = sfxSlider.value * MAX_VOLUME;
        SaveVolume();
    }

    private void SaveVolume()
    {
        PlayerPrefs.SetFloat("SfxVolume", sfxSource.volume);
    }

    private void LoadVolume()
    {
        sfxSource.volume = PlayerPrefs.GetFloat("SfxVolume");
        sfxSlider.value = sfxSource.volume / MAX_VOLUME;
    }
}
