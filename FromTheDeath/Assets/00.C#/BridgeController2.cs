using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BridgeController2 : MonoBehaviour
{
    int maxY;
    int minY;
    int way;

    void Start()
    {
        maxY = 11;
        minY = -2;
        way = 2;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        this.transform.position += Vector3.up * Time.fixedDeltaTime * way;

        if (this.transform.position.y >= maxY)
        {
            way = -2;
        }
        if (this.transform.position.y <= minY)
        {
            way = 2;
        } 
    }

    
}
