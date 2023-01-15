using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Capoo2 : CapooBase
{
    // Start is called before the first frame update
    void Start()
    {
        mergeScore = 200;
        capooTag = "Capoo2";
        nextCapooTag = "Capoo3";
        gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
        soundEffectManager = GameObject.FindGameObjectWithTag("SoundEffectManager").GetComponent<SoundEffectManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
