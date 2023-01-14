using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Capoo2 : MonoBehaviour
{
    // For resolving collisions between 2 Capoos only once
    public bool isFirstCapoo;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // If collide with another Capoo2 GameObject, destroy both and create a new Capoo3 at the point between them
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Only do this for the first Capoo this code is run on when a collision happens between 2 Capoos
        if (collision.gameObject.tag == "Capoo2" && !collision.gameObject.GetComponent<Capoo2>().isFirstCapoo) {
            isFirstCapoo = true;
            Destroy(gameObject);
            Destroy(collision.gameObject);
            // Instantiate a new Capoo3 at the point between the two Capoo2s
            Instantiate(GameObject.FindWithTag("Capoo3"), (transform.position + collision.gameObject.transform.position) / 2, Quaternion.identity);
        }
    }
}
