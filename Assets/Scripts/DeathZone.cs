using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathZone : MonoBehaviour
{
    public float DEATH_DELAY = 5.0f;

    public GameManager gameManager;
    public HashSet<GameObject> capoosInside = new HashSet<GameObject>(); // Array of Capoos currently inside the DeathZone
    public float capoosInsideElapsedTime = 0.0f; // Continuous amount of time that there have been Capoos inside the DeathZone

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        // Note: need to consider whether the capoo currently inside is the currentCapoo!
        if (capoosInside.Count == 0 || (capoosInside.Count == 1 && gameManager.currentCapoo && capoosInside.Contains(gameManager.currentCapoo)))
        {
            capoosInsideElapsedTime = 0.0f;
        }
        else
        {
            capoosInsideElapsedTime += Time.deltaTime;
            if (capoosInsideElapsedTime >= DEATH_DELAY && !gameManager.gameIsOver)
            {
                gameManager.GameOver();
            }
        }
    }

    // If any Capoos collide with the DeathZone, log a message
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Capoos"))
        {
            capoosInside.Add(other.gameObject);
        }
    }

    // If any Capoos leave the DeathZone, log a message
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Capoos"))
        {
            capoosInside.Remove(other.gameObject);
        }
    }
}
