using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemybehaviour : MonoBehaviour
{
    private GameObject Player;
    public float minDistance = 3f;
    public float moveSpeed = 5f;
    CharacterController _controller;
    Transform target;
    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.FindWithTag("Player"); 
        target = Player.transform;
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 targetPos = Player.transform.position;
        targetPos += ((Vector2)transform.position - (Vector2)Player.transform.position).normalized * minDistance;
        transform.position = Vector2.MoveTowards(transform.position, targetPos, moveSpeed * Time.deltaTime);
        /*Vector3 direction = target.position - transform.position;

        direction = direction.normalized;

        Vector3 velocity = direction * moveSpeed;
 
        transform.GetComponent<Rigidbody2D>().velocity = (velocity * Time.deltaTime);*/
    }
}
