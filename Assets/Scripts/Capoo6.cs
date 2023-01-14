using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Capoo6 : CapooBase
{
    // Start is called before the first frame update
    void Start()
    {
        mergeScore = 1300;
        capooTag = "Capoo6";
        nextCapooTag = "Capoo7";       
        gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
