using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        

    }

    // Update is called once per frame
    void Update()
    {
        transform.GetComponent<Rigidbody2D>().velocity = (transform.GetComponent<Rigidbody2D>().velocity).normalized * 20f;
        
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            collision.gameObject.SendMessage("ApplyDamage", 1);
            Destroy (gameObject);
            Debug.Log("Collision");
        }
    }
    void OnBecameInvisible() {
        Destroy(gameObject);
    }
}
