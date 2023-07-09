using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    }
    public void ApplyDamage(float dmg){
        if(!godMode){
            health -= dmg;
            Debug.Log("Damage");
        }
        scoremanager.SendMessage("IncrementScore",((15f-health)*10f)*10f);
        if(health<=0){
            Destroy (gameObject);
    }
    }
    public void GodMode(){
        if(!godMode){
            godMode = true;
            moveSpeed = initialMoveSpeed * 1.5f;
            Invoke("ClearGodMode", 5f);
        }
    }
    private void ClearGodMode(){
        godMode = false;
        moveSpeed = initialMoveSpeed;
    }
}
