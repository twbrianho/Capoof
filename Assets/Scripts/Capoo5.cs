using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Capoo5 : MonoBehaviour
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

    // If collide with another Capoo5 GameObject, destroy both and create a new Capoo6 at the point between them
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Only do this for the first Capoo this code is run on when a collision happens between 2 Capoos
        if (collision.gameObject.tag == "Capoo5" && !collision.gameObject.GetComponent<Capoo5>().isFirstCapoo) {
            isFirstCapoo = true;
            Destroy(gameObject);
            Destroy(collision.gameObject);
            // Instantiate a new Capoo6 at the point between the two Capoo5s
            Instantiate(GameObject.FindWithTag("Capoo6"), (transform.position + collision.gameObject.transform.position) / 2, Quaternion.identity);
        }
    }
}
