using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemygunmechanic : MonoBehaviour
{
    private float xspeed;
    private float lastPosition;
    private bool rotate;
    private bool shoot = true;
    public GameObject bullet;
    public float bulletSpeed = 10;
    private GameObject Player;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.localPosition = new Vector2 (0, 0);
        Player = GameObject.FindWithTag("Player"); 
        Vector3 playerPos = Player.transform.position;
        //Vector3 playerPos = new Vector3(playerX, playerY, 0);
        Vector2 direction = Player.transform.position - transform.parent.position;
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
         if(shoot){
            shooting();
            shoot = false;
            Invoke("shootCD", Random.Range(0.5f,3f));
         }
    }
    private void shooting(){
        Debug.Log("shooting");
        Player = GameObject.FindWithTag("Player"); 
        Vector3 playerPos = Player.transform.position;
        /*GameObject obj = Instantiate(bullet) as GameObject;
        obj.transform.parent = transform;
        Rigidbody bulletClone = (Rigidbody) Instantiate(bullet, transform.position, transform.rotation);
		bulletClone.velocity = transform.forward * bulletSpeed;*/
        var instanceBullet = Instantiate (bullet, transform.position, Quaternion.identity);
        //instanceBullet.GetComponent<Rigidbody2D>().AddForce(transform.forward * bulletSpeed);
        instanceBullet.transform.rotation = transform.rotation;
        instanceBullet.GetComponent<Rigidbody2D>().velocity = (Player.transform.position-transform.position).normalized * bulletSpeed;
        
    }
    private void shootCD(){
        shoot = true;
    }
}
