using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Capoo4 : CapooBase
{
    // Start is called before the first frame update
    void Start()
    {
        baseScore = 500;
        mergeScore = 800;
        capooTag = "Capoo4";
        nextCapooTag = "Capoo5";
        gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
