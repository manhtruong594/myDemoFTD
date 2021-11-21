using UnityEngine;

public class FollowPlayer : MonoBehaviour
{

    public Vector3 offSet;
    Vector3 target;
    public int speed;


    // Update is called once per frame
    void Update()
    {
        if (HechmanController.Instant.target)
            return;

        target = PlayerController.Instant.transform.position - offSet;

        this.transform.position = Vector3.Lerp(this.transform.position, target, speed * Time.deltaTime);

    }
}
