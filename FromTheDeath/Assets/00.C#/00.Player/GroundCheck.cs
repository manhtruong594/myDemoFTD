using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundCheck : Singleton<GroundCheck>
{

    public bool isGround;

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Ground"))
        {
            isGround = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Ground"))
        {
            isGround = false;
        }
    }
}
