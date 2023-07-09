using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scoremanager : MonoBehaviour
{
    [HideInInspector]public float score = 0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("Score: " + score);
    }

    public void IncrementScore(float num){
        score +=num;
    }
    public void DecrementScore(float num){
        score -=num;
    }
}
