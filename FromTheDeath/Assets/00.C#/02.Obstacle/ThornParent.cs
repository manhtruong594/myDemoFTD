using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThornParent : MonoBehaviour
{
    [SerializeField] int fallenSpeed;

    // Start is called before the first frame update
    void Start()
    {
        this.transform.position = Vector3.zero;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        this.transform.position += Vector3.down * Time.fixedDeltaTime * fallenSpeed;
        if (this.transform.position.y <= -20)
        {
            this.transform.position = Vector3.zero;
            gameObject.SetActive(false);
        }
    }

}
