using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class movement : MonoBehaviour
{
    
    public float moveSpeed = 9;
    public float playerX;
    public float playerY;
    public float minDistance = 0.3f;
    public float health = 10f;
    public GameObject scoremanager;
    private bool godMode;
    private float initialMoveSpeed;
    [HideInInspector]public float godmodetimer;


    // Start is called before the first frame update
    void Start()
    {
        Vector3 mousePosition = Input.mousePosition;
        initialMoveSpeed=moveSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePosition += ((Vector2)transform.position - mousePosition).normalized * minDistance;
        transform.position = Vector2.MoveTowards(transform.position, mousePosition, moveSpeed * Time.deltaTime);
        playerX = transform.position.x;
        playerY = transform.position.y;
        transform.eulerAngles = new Vector3 (transform.eulerAngles.x, transform.eulerAngles.y, 0);
        if (health<10){
            health += 0.5f * Time.deltaTime;
        }
        if (health>10){
            health = 10;
        }
        Debug.Log("Health: " + health);
        Vector3 minScreenBounds = Camera.main.ScreenToWorldPoint(new Vector3(0, 0, 0));
	    Vector3 maxScreenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 0));

		transform.position = new Vector3(Mathf.Clamp(transform.position.x, minScreenBounds.x + 1, maxScreenBounds.x - 1),Mathf.Clamp(transform.position.y, minScreenBounds.y + 1, maxScreenBounds.y - 1), transform.position.z);
        
        godmodetimer-=Time.deltaTime;
        if(godmodetimer<=0){
            godmodetimer=0;
            godMode=false;
            moveSpeed=initialMoveSpeed;
        }
    }
    public void ApplyDamage(float dmg){
        if(!godMode){
            health -= dmg;
            Debug.Log("Damage");
        }
        scoremanager.SendMessage("IncrementScore",((15f-health)*10f)*10f);
        if(health<=0){
            SceneManager.LoadScene(2);
    }
    }
    public void GodMode(){
        if(!godMode){
            godMode = true;
            godmodetimer=1.5f;
            moveSpeed = initialMoveSpeed * 1.5f;
        }
        else{
            godmodetimer=1.5f;
        }
        
    }
}
