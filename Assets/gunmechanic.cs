using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gunmechanic : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        //Vector3 playerPos = new Vector3(playerX, playerY, 0);
        Vector2 direction = mousePosition - transform.parent.position;
        float angle = Vector2.SignedAngle(Vector2.right, direction);
        Vector3 targetRotation = new Vector3(0, 0, angle);
        transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.Euler(targetRotation), 20);
    }
}
