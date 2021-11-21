using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BridgeController : MonoBehaviour
{

    public bool canMoving;
    [SerializeField] GameObject bridge;


    // Start is called before the first frame update
    void Start()
    {
        canMoving = false;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (!canMoving)
        {
            return;
        }
        Moving();
        
    }


    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            canMoving = true;
        }

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            canMoving = false;
        }
    }



    void Moving()
    {

        bridge.transform.position += Vector3.up * Time.fixedDeltaTime;

    }
}
