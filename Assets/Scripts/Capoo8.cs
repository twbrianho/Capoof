using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Capoo8 : CapooBase
{
    // Start is called before the first frame update
    void Start()
    {
        baseScore = 3400;
        mergeScore = 5500;
        capooTag = "Capoo8";
        nextCapooTag = "Capoo1";
        gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
