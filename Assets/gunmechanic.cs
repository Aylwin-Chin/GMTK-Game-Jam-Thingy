using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gunmechanic : MonoBehaviour
{
    private float xspeed;
    private float lastPosition;
    private bool rotate;
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
        xspeed = (transform.position.x - lastPosition) / Time.deltaTime;
        lastPosition = transform.position.x;
        /*if(xspeed<0){
            if(rotate){
                transform.position = new Vector3(-0.75f,0,0) + transform.parent.position;
                rotate = false;
            }
            else{
                if(xspeed<3){
                    rotate = true;
                }
            }
        }
        else
        {
            if(rotate){
                transform.position = new Vector3(0.75f,0,0) + transform.parent.position;
                rotate = false;
            }
            else{
                if(xspeed>3){
                    rotate = true;
                }
            }
        }*/
        transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.Euler(targetRotation), 20);
    }
}
