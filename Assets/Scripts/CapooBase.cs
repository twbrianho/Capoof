using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CapooBase : MonoBehaviour
{
    private float STARTING_SCALE = 0.0f;
    private float SCALE_RATE = 2.0f;  // Size increase per second

    public GameManager gameManager;
    public SoundEffectManager soundEffectManager;
    
    public bool isInvolvedInCollision = false; // Ensure each Capoo can be involved in only one collision
    private float mergeCooldown = 0.5f; // The time between when a Capoo is created and when it can be merged with another Capoo
    private float growTimer = 0.0f; // Time elapsed since the Capoo was created

    public virtual float maxSize { get; set; } // The max size a Capoo should be
    public virtual int mergeScore { get; set; } // The score to be awarded when this Capoo is merged with another Capoo
    public virtual string capooTag { get; set; } // For identifying other Capoos with the same tag
    public virtual string nextCapooTag { get; set; } // The capoo to be created when this one collides with another

    private float LevelSizeModifier() 
    {
        return (gameManager.level - 1) * 0.05f;
    }

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
        soundEffectManager = GameObject.FindGameObjectWithTag("SoundEffectManager").GetComponent<SoundEffectManager>();
        // Start new Capoos at a smaller size
        transform.localScale = new Vector3(STARTING_SCALE * (maxSize + LevelSizeModifier()), STARTING_SCALE * (maxSize + LevelSizeModifier()), 0);
    }

    private void Update()
    {
        // If the merge cooldown is still active, reduce it by the time since the last frame
        if (mergeCooldown > 0) {
            mergeCooldown -= Time.deltaTime;
        }
        // If the Capoo is not up to full size, increase its size
        if (transform.localScale.x < 1 * (maxSize + LevelSizeModifier())) {
            // Grow at a rate of SCALE_RATE per second
            growTimer += Time.deltaTime; // deltaTime: seconds since the last frame
            // Note: Ensure the Capoo doesn't grow larger than the max size
            float currentScale = Mathf.Min((STARTING_SCALE + growTimer * SCALE_RATE), 1) * (maxSize + LevelSizeModifier());
            transform.localScale = new Vector3(currentScale, currentScale, 0);
        }
    }

    // If collide with another Capoo of the same size, destroy both and create a new Capoo of a larger size at the point between them
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Ignore collisions with non-relevant objects
        if (collision.gameObject.tag != capooTag) {
            return;
        }
        // If still in the merge cooldown, don't do anything
        if (mergeCooldown > 0) {
            return;
        }
        // If this Capoo has already been involved in a collision (i.e. the other Capoo is handling the collision), don't do anything
        if (isInvolvedInCollision || collision.gameObject.GetComponent<CapooBase>().isInvolvedInCollision) {
            return;
        }
        // Set the collision handler flags
        isInvolvedInCollision = true;
        collision.gameObject.GetComponent<CapooBase>().isInvolvedInCollision = true;
        // Calculate the middle point between the two Capoos
        Vector3 middlePoint = (transform.position + collision.gameObject.transform.position) / 2;
        // Instantiate a new Capoo at the point between the two original Capoos
        GameObject newCapoo = Instantiate(GameObject.FindWithTag(nextCapooTag), middlePoint, Quaternion.identity);
        // Give the new Capoo the average velocity of the two original Capoos
        newCapoo.GetComponent<Rigidbody2D>().velocity = (GetComponent<Rigidbody2D>().velocity + collision.gameObject.GetComponent<Rigidbody2D>().velocity) / 2;
        // Play the merge sound effect
        soundEffectManager.PlayCapooMergeSound();
        // Destroy the two original Capoos
        Destroy(gameObject);
        Destroy(collision.gameObject);
        // Award the player the merge score
        gameManager.AddScore(mergeScore);
        // If Capoo8s were merged, increase the level
        if (capooTag == "Capoo8") {
            gameManager.IncreaseLevel();
        }
    }
}
