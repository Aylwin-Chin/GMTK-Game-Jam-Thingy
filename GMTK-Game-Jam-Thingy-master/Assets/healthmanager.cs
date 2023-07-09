using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class healthmanager : MonoBehaviour
{
    private float health;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        health = transform.parent.GetComponent<movement>().health;
        transform.localScale = new Vector3((health/10)*2f, 0.15f, 0f);
        transform.localPosition = new Vector3(0f+((health-10f)/10f), -0.8f, 0f);
    }
}
