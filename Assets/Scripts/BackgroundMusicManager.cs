using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BackgroundMusicManager : MonoBehaviour
{
    public float MAX_VOLUME = 1.0f;

    [SerializeField] public Slider bgmSlider;

    public AudioSource bgmSource;
    [SerializeField] public AudioClip[] bgmClips;

    // Start is called before the first frame update
    void Start()
    {
        bgmSource = GetComponent<AudioSource>();

        // Load the volume from the previous session
        if (PlayerPrefs.HasKey("BgmVolume"))
        {
            LoadVolume();
        }
        else
        {
            SetVolume();
        }
        
        // Play a random BGM from the array of potential BGMs
        bgmSource.clip = bgmClips[Random.Range(0, bgmClips.Length)];
        bgmSource.Play();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetVolume()
    {
        bgmSource.volume = bgmSlider.value * MAX_VOLUME;
        SaveVolume();
    }

    private void SaveVolume()
    {
        PlayerPrefs.SetFloat("BgmVolume", bgmSource.volume);
    }

    private void LoadVolume()
    {
        bgmSource.volume = PlayerPrefs.GetFloat("BgmVolume");
        bgmSlider.value = bgmSource.volume / MAX_VOLUME;
    }
}
