using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public float RESPAWN_DELAY = 0.8f;

    public DeathZone deathZone;

    GameObject Capoo1;
    GameObject Capoo2;
    GameObject Capoo3;
    GameObject Capoo4;
    GameObject Capoo5;
    GameObject Capoo6;
    GameObject Capoo7;
    GameObject Capoo8;

    public GameObject currentCapoo;
    private float respawnCountdown = 0.0f;
    
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
        // Count down the respawn timer
        if (respawnCountdown > 0 && currentCapoo == null) {
            respawnCountdown -= Time.deltaTime;
            // During this time, there is nothing else to do, so return
            return;
        }

        // Get mouse position in world space
        Vector3 mouseWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        
        // If there is no currentCapoo, spawn a new random Capoo and set it as currentCapoo.
        // If there are still Capoos in the death zone, don't spawn a new Capoo! This could cause a Capoo explosion.
        if (currentCapoo == null && deathZone.capoosInside.Count == 0) {
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
