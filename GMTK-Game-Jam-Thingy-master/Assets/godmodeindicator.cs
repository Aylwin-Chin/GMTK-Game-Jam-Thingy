using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class godmodeindicator : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float godmodetimer = transform.parent.GetComponent<movement>().godmodetimer;
        transform.localScale = new Vector3((godmodetimer/1.5f)*2f, 0.15f, 0f);
        transform.localPosition = new Vector3(0f-((1.5f-godmodetimer)/1.5f)*1f, -0.7f, 0f);
    }
}
