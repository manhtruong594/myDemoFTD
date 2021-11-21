using UnityEngine;
using System.Collections;


public class CameraMoving : Singleton<CameraMoving>
{
    public int speed, minXToFollow, maxXToFollow;
    float shakeTime, shakePower;
    [SerializeField] MapData mapDt;

    [SerializeField] Vector3 offSet;
    Vector3 target;

    [SerializeField] GameObject character;


    private void Start()
    {
        this.transform.position = character.transform.position;
        minXToFollow = mapDt.minX1;
        maxXToFollow = mapDt.maxX1;
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        if (!character || character.transform.position.x >= maxXToFollow || character.transform.position.x <= minXToFollow)
            return;

        FollowCharacter();
    }

    private void LateUpdate()
    {
        if (shakeTime >0)
        {
            shakeTime -= Time.deltaTime;

            float x = Random.Range(-1f, 1f) * shakePower;
            float y = Random.Range(-1f, 1f) * shakePower;

            this.transform.position += new Vector3(x, y, -10);
        }

    }


    void FollowCharacter()
    {
        target = character.transform.position - offSet;
        target.z = -10;

        this.transform.position = Vector3.Lerp(this.transform.position, target, speed * Time.fixedDeltaTime);

    }

    public void StartShake(float time, float power)
    {
        shakeTime = time;
        shakePower = power;

    }
    
    
}
