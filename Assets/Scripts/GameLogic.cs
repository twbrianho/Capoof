using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameLogic : MonoBehaviour
{
    private float RESPAWN_DELAY = 0.8f;
    private float DEATH_DELAY = 2.0f;

    GameObject Capoo1;
    GameObject Capoo2;
    GameObject Capoo3;
    GameObject Capoo4;
    GameObject Capoo5;
    GameObject Capoo6;
    GameObject Capoo7;
    GameObject Capoo8;

    private GameObject currentCapoo;
    private float respawnCountdown = 0.0f;

    public GameObject DeathLine; // If Capoos stay above this line for too long, you lose
    private bool capoosAboveLineBefore; // Keeps track of whether Capoos were above the line on the previous frame
    private float capoosAboveLineElapsedTime = 0.0f; // Keeps track of the continuous time that Capoos have been above the line
    
    // Start is called before the first frame update
    void Start()
    {
        Capoo1 = GameObject.FindWithTag("Capoo1");
        Capoo2 = GameObject.FindWithTag("Capoo2");
        Capoo3 = GameObject.FindWithTag("Capoo3");
        Capoo4 = GameObject.FindWithTag("Capoo4");
        Capoo5 = GameObject.FindWithTag("Capoo5");
        Capoo6 = GameObject.FindWithTag("Capoo6");
        Capoo7 = GameObject.FindWithTag("Capoo7");
        Capoo8 = GameObject.FindWithTag("Capoo8");
        
        // Start with a Capoo1 at (0, 4, 0)
        currentCapoo = Instantiate(Capoo1, new Vector3(0, 4, 0), Quaternion.identity);
        // Turn gravity off for currentCapoo
        currentCapoo.GetComponent<Rigidbody2D>().gravityScale = 0;
    }

    // Update is called once per frame
    void Update()
    {        
        // Get all Capoos in the scene (from Capoo1 through Capoo8)
        GameObject[] allCapoo1s = GameObject.FindGameObjectsWithTag("Capoo1");
        GameObject[] allCapoo2s = GameObject.FindGameObjectsWithTag("Capoo2");
        GameObject[] allCapoo3s = GameObject.FindGameObjectsWithTag("Capoo3");
        GameObject[] allCapoo4s = GameObject.FindGameObjectsWithTag("Capoo4");
        GameObject[] allCapoo5s = GameObject.FindGameObjectsWithTag("Capoo5");
        GameObject[] allCapoo6s = GameObject.FindGameObjectsWithTag("Capoo6");
        GameObject[] allCapoo7s = GameObject.FindGameObjectsWithTag("Capoo7");
        GameObject[] allCapoo8s = GameObject.FindGameObjectsWithTag("Capoo8");
        
        // Check if any Capoos are above the death line
        bool capoosAboveLineNow = false;
        foreach (GameObject[] capoos in new GameObject[][] { allCapoo1s, allCapoo2s, allCapoo3s, allCapoo4s, allCapoo5s, allCapoo6s, allCapoo7s, allCapoo8s }) {
            foreach (GameObject capoo in capoos) {
                if (capoo == currentCapoo) {
                    // Ignore the currentCapoo
                    continue;
                }
                if (capoo.transform.position.y > DeathLine.transform.position.y) {
                    // If there were already Capoos above the death line, increment the timer
                    if (capoosAboveLineBefore == true) {
                        capoosAboveLineElapsedTime += Time.deltaTime;
                        if (capoosAboveLineElapsedTime > DEATH_DELAY) {
                            // TODO: Game over state
                            Debug.Log("Game over!");
                        }
                    }
                    capoosAboveLineNow = true;
                    capoosAboveLineBefore = true;
                    break;
                }
            }
        }
        // If none of the Capoos are above the death line, reset the timer
        if (!capoosAboveLineNow) {
            capoosAboveLineElapsedTime = 0.0f;
        }

        // Get mouse position in world space
        Vector3 mouseWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        // Count down the respawn timer
        if (respawnCountdown > 0 && currentCapoo == null) {
            respawnCountdown -= Time.deltaTime;
            // During this time, there is nothing else to do, so return
            return;
        }
        
        // If there is no currentCapoo, spawn a new random Capoo and set it as currentCapoo.
        // NOTE: If there are still Capoos above the death line, don't spawn a new Capoo! This could cause a Capoo explosion.
        else if (currentCapoo == null && capoosAboveLineNow == false) {
            // Spawn a random Capoo between Capoo1 and Capoo3
            if (Random.Range(0, 2) == 0) {
                currentCapoo = Instantiate(Capoo1, new Vector3(mouseWorldPos.x, 4, 0), Quaternion.identity);
            } else {
                currentCapoo = Instantiate(Capoo2, new Vector3(mouseWorldPos.x, 4, 0), Quaternion.identity);
            }
            // Turn gravity off for currentCapoo
            currentCapoo.GetComponent<Rigidbody2D>().gravityScale = 0;
        }

        if (currentCapoo) {
            // Set currentCapoo velocity towards mouse X position on screen
            // Use velocity instead of position so that it doesn't go through walls
            currentCapoo.GetComponent<Rigidbody2D>().velocity = new Vector2(mouseWorldPos.x - currentCapoo.transform.position.x, 0) * 20;

            // Set currentCapoo's Y position to 4
            currentCapoo.transform.position = new Vector3(currentCapoo.transform.position.x, 4, 0);

            // If mouse is clicked
            if (Input.GetMouseButtonUp(0)) {
                // Turn gravity back on for currentCapoo
                currentCapoo.GetComponent<Rigidbody2D>().gravityScale = 1;
                // Start a timer to spawn a new Capoo at 0.5 seconds
                respawnCountdown = RESPAWN_DELAY;
                currentCapoo = null;
            }
        }
    }
}
