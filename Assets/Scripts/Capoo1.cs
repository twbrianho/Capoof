using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Capoo1 : CapooBase
{
    // Start is called before the first frame update
    void Start()
    {
        mergeScore = 100;
        capooTag = "Capoo1";
        nextCapooTag = "Capoo2";
        gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
        soundEffectManager = GameObject.FindGameObjectWithTag("SoundEffectManager").GetComponent<SoundEffectManager>();
    }
}
