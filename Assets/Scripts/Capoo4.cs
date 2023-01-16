using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Capoo4 : CapooBase
{
    // Start is called before the first frame update
    void Start()
    {
        mergeScore = 500;
        capooTag = "Capoo4";
        nextCapooTag = "Capoo5";
        gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
        soundEffectManager = GameObject.FindGameObjectWithTag("SoundEffectManager").GetComponent<SoundEffectManager>();
    }
}
