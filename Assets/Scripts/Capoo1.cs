using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Capoo1 : CapooBase
{
    // Start is called before the first frame update
    void Start()
    {
        baseScore = 100;
        mergeScore = 100;
        capooTag = "Capoo1";
        nextCapooTag = "Capoo2";
        gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
