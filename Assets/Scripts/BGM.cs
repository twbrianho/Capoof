using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGM : MonoBehaviour
{
    [SerializeField] public AudioClip[] bgmClips;
    public AudioSource bgmSource;

    // Start is called before the first frame update
    void Start()
    {
        bgmSource = GetComponent<AudioSource>();
        // Play a random BGM from the array of potential BGMs
        bgmSource.clip = bgmClips[Random.Range(0, bgmClips.Length)];
        bgmSource.Play();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
