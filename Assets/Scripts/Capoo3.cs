using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Capoo3 : CapooBase
{
    // Start is called before the first frame update
    void Start()
    {
        mergeScore = 300;
        capooTag = "Capoo3";
        nextCapooTag = "Capoo4";
        gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
