using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Capoo5 : CapooBase
{
    // Start is called before the first frame update
    void Start()
    {
        baseScore = 800;
        mergeScore = 1300;
        capooTag = "Capoo5";
        nextCapooTag = "Capoo6";
        gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
