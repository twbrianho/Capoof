using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameLogic : MonoBehaviour
{
    GameObject capoo1;
    GameObject capoo2;
    GameObject capoo3;
    GameObject capoo4;
    GameObject capoo5;
    GameObject capoo6;

    GameObject currentCapoo;
    float respawnCountdown;
    
    // Start is called before the first frame update
    void Start()
    {
        capoo1 = GameObject.FindWithTag("Capoo1");
        capoo2 = GameObject.FindWithTag("Capoo2");
        capoo3 = GameObject.FindWithTag("Capoo3");
        capoo4 = GameObject.FindWithTag("Capoo4");
        capoo5 = GameObject.FindWithTag("Capoo5");
        capoo6 = GameObject.FindWithTag("Capoo6");

        // Start with a Capoo1 at (0, 4, 0)
        currentCapoo = Instantiate(capoo1, new Vector3(0, 4, 0), Quaternion.identity);
        // Turn gravity off for currentCapoo
        currentCapoo.GetComponent<Rigidbody2D>().gravityScale = 0;
    }

    // Update is called once per frame
    void Update()
    {        
        // Get mouse position in world space
        Vector3 mouseWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        // Count down the timer
        if (respawnCountdown > 0 && currentCapoo == null) {
            respawnCountdown -= Time.deltaTime;
            // During this time, there is nothing else to do, so return
            return;
        }
        
        // If timer is done but there is no currentCapoo, spawn a new random Capoo and set it as currentCapoo
        else if (currentCapoo == null) {
            if (Random.Range(0, 2) == 0) {
                currentCapoo = Instantiate(capoo1, new Vector3(mouseWorldPos.x, 4, 0), Quaternion.identity);
            } else {
                currentCapoo = Instantiate(capoo2, new Vector3(mouseWorldPos.x, 4, 0), Quaternion.identity);
            }
            // Turn gravity off for currentCapoo
            currentCapoo.GetComponent<Rigidbody2D>().gravityScale = 0;
        }

        // Set currentCapoo velocity towards mouse X position on screen
        currentCapoo.GetComponent<Rigidbody2D>().velocity = new Vector2(mouseWorldPos.x - currentCapoo.transform.position.x, 0) * 20;
        
        // Set currentCapoo's Y position to 4
        currentCapoo.transform.position = new Vector3(currentCapoo.transform.position.x, 4, 0);

        // If mouse is clicked
        if (Input.GetMouseButtonDown(0)) {
            // Turn gravity back on for currentCapoo
            currentCapoo.GetComponent<Rigidbody2D>().gravityScale = 1;
            // Start a timer to spawn a new Capoo at 0.5 seconds
            respawnCountdown = 0.5f;
            currentCapoo = null;
        }
    }
}
