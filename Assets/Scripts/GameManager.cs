using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class GameManager : MonoBehaviour
{
    public float RESPAWN_DELAY = 1.0f;

    public SoundEffectManager soundEffectManager;
    public DeathZone deathZone;
    public GameObject gameOverScreen;
    public Text scoreText;

    GameObject Capoo1;
    GameObject Capoo2;
    GameObject Capoo3;
    GameObject Capoo4;
    GameObject Capoo5;
    GameObject Capoo6;
    GameObject Capoo7;
    GameObject Capoo8;

    public int score;
    public GameObject currentCapoo;
    private bool gameIsOver;
    private float respawnCountdown;

    public void AddScore(int points) {
        if (gameIsOver) {
            // Don't add score if game is over
            return;
        }
        score += points;
        scoreText.text = score.ToString();
    }

    private bool IsMouseOverUI() {
        return EventSystem.current.IsPointerOverGameObject();
    }

    private GameObject GetRandomCapoo() {
        // Based on the current score, get a random Capoo
        int upperRange;
        if (score <= 100) {
            upperRange = 1;
        }
        else if (score <= 500) {
            upperRange = 2;
        }
        else if (score <= 2500) {
            upperRange = 3;
        }
        else {
            upperRange = 4;
        }
        int randomCapoo = Random.Range(0, upperRange);
        if (randomCapoo == 0) {
            return Capoo1;
        }
        else if (randomCapoo == 1) {
            return Capoo2;
        }
        else if (randomCapoo == 2) {
            return Capoo3;
        }
        else {
            return Capoo4;
        }
    }

    public void GameOver()
    {
        gameIsOver = true;
        gameOverScreen.SetActive(true);
        // Destroy current Capoo if there is still one hanging there
        if (currentCapoo != null) {
            Destroy(currentCapoo);
        }
    }

    public void RestartGame() 
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    
    // Start is called before the first frame update
    void Start()
    {
        // Initialize variables
        score = 0;
        respawnCountdown = 0;

        soundEffectManager = GameObject.FindGameObjectWithTag("SoundEffectManager").GetComponent<SoundEffectManager>();
        deathZone = GameObject.FindGameObjectWithTag("DeathZone").GetComponent<DeathZone>();
        scoreText.text = score.ToString();

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
        // Prevent game from continuing if game is over
        if (gameIsOver) { return; }
        
        // Count down the respawn timer
        if (respawnCountdown > 0 && currentCapoo == null) {
            respawnCountdown -= Time.deltaTime;
            // During this time, there is nothing else to do, so return
            return;
        }

        // Get mouse position in world space
        Vector3 mouseWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        // Clamp the mouse X position to the valid area between -8.2 ~ 4
        float validStartX = Mathf.Clamp(mouseWorldPos.x, -8.2f, 4.0f);
        
        // If there is no currentCapoo, spawn a new random Capoo and set it as currentCapoo.
        // If there are still Capoos in the death zone, don't spawn a new Capoo! This could cause a Capoo explosion.
        if (currentCapoo == null && deathZone.capoosInside.Count == 0) {
            // Spawn a random Capoo based on the score
            currentCapoo = Instantiate(GetRandomCapoo(), new Vector3(validStartX, 4, 0), Quaternion.identity);
            // Turn gravity off for currentCapoo
            currentCapoo.GetComponent<Rigidbody2D>().gravityScale = 0;
        }

        if (currentCapoo) {
            // Set currentCapoo velocity towards mouse X position on screen
            // Use velocity instead of position so that it doesn't go through walls
            currentCapoo.GetComponent<Rigidbody2D>().velocity = new Vector2(validStartX - currentCapoo.transform.position.x, 0) * 20;

            // Set currentCapoo's Y position to 4
            currentCapoo.transform.position = new Vector3(currentCapoo.transform.position.x, 4, 0);

            if (Input.GetMouseButtonUp(0) && !IsMouseOverUI()) {
                // Turn gravity back on for currentCapoo
                currentCapoo.GetComponent<Rigidbody2D>().gravityScale = 1;
                // Play the Capoo launch sound effect
                soundEffectManager.PlayCapooLaunchSound();
                // Start a timer to spawn a new Capoo at 0.5 seconds
                respawnCountdown = RESPAWN_DELAY;
                currentCapoo = null;
            }
        }
    }
}
