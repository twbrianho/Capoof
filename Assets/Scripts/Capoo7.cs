using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Capoo7 : CapooBase
{
    // Start is called before the first frame update
    void Start()
    {
        baseScore = 2100;
        mergeScore = 3400;
        capooTag = "Capoo7";
        nextCapooTag = "Capoo8";
        gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
