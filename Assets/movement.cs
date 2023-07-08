using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement : MonoBehaviour
{
    
    public float moveSpeed = 7;
    public float playerX;
    public float playerY;
    public float minDistance = 0.3f;

    // Start is called before the first frame update
    void Start()
    {
        Vector3 mousePosition = Input.mousePosition;
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePosition += ((Vector2)transform.position - mousePosition).normalized * minDistance;
        transform.position = Vector2.MoveTowards(transform.position, mousePosition, moveSpeed * Time.deltaTime);
        playerX = transform.position.x;
        playerY = transform.position.y;

    }
}
