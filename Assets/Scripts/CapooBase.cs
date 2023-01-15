using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CapooBase : MonoBehaviour
{
    public GameManager gameManager;
    
    // For resolving collisions between 2 Capoos only once
    public bool isCollisionHandler = false;

    public int baseScore; // The score to be awarded when this Capoo is dropped.
    public int mergeScore; // The score to be awarded when this Capoo is merged with another Capoo.
    public string capooTag; // For identifying other Capoos with the same tag
    public string nextCapooTag; // The capoo to be created when this one collides with another

    public SoundEffectManager soundEffectManager;

    // If collide with another Capoo of the same size, destroy both and create a new Capoo of a larger size at the point between them
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Only do this for the first Capoo this code is run on when a collision happens between 2 Capoos
        if (collision.gameObject.tag == capooTag && !collision.gameObject.GetComponent<CapooBase>().isCollisionHandler) {
            isCollisionHandler = true;
            // Instantiate a new Capoo at the point between the two original Capoos
            GameObject newCapoo = Instantiate(GameObject.FindWithTag(nextCapooTag), (transform.position + collision.gameObject.transform.position) / 2, Quaternion.identity);
            // Give the new Capoo the average velocity of the two original Capoos
            newCapoo.GetComponent<Rigidbody2D>().velocity = (GetComponent<Rigidbody2D>().velocity + collision.gameObject.GetComponent<Rigidbody2D>().velocity) / 2;
            // Play the merge sound effect
            soundEffectManager.PlayCapooMergeSound();
            // Destroy the two original Capoos
            Destroy(gameObject);
            Destroy(collision.gameObject);
            // Award the player the merge score
            gameManager.AddScore(mergeScore);
        }
    }
}
