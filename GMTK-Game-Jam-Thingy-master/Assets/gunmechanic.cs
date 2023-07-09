using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gunmechanic : MonoBehaviour
{
    private float xspeed;
    private float lastPosition;
    private bool rotate;
    private bool shoot = true;
    public GameObject bullet;
    public float bulletSpeed = 10;
    public GameObject scoremanager;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.localPosition = new Vector2 (0, 0);
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
        if(Input.GetMouseButton(0)){
         if(shoot){
            if(scoremanager.GetComponent<scoremanager>().score>50)
            {shooting();
            shoot = false;
            Invoke("shootCD", 0.2f);
            }
         }
        }
    }
    private void shooting(){
        Debug.Log("shooting");
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        /*GameObject obj = Instantiate(bullet) as GameObject;
        obj.transform.parent = transform;
        Rigidbody bulletClone = (Rigidbody) Instantiate(bullet, transform.position, transform.rotation);
		bulletClone.velocity = transform.forward * bulletSpeed;*/
        var instanceBullet = Instantiate (bullet, transform.position, Quaternion.identity);
        //instanceBullet.GetComponent<Rigidbody2D>().AddForce(transform.forward * bulletSpeed);
        instanceBullet.transform.rotation = transform.rotation;
        instanceBullet.GetComponent<Rigidbody2D>().velocity = (mousePosition-transform.position).normalized * -bulletSpeed;
        scoremanager.SendMessage("DecrementScore",50);
        
    }
    private void shootCD(){
        shoot = true;
    }
}
