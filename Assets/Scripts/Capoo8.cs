using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Capoo8 : CapooBase
{
    // Start is called before the first frame update
    void Start()
    {
        mergeScore = 3400;
        capooTag = "Capoo8";
        nextCapooTag = "Capoo1";
        gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
        soundEffectManager = GameObject.FindGameObjectWithTag("SoundEffectManager").GetComponent<SoundEffectManager>();
    }
}
