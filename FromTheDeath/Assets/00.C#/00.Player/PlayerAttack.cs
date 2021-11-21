using System.Collections;
using UnityEngine;

public class PlayerAttack : Singleton<PlayerAttack>
{
    public float atkSpeed;
    float atkTimer;
    public bool isAttacking;

    // Start is called before the first frame update
    void Start()
    {
        atkTimer = atkSpeed;
        isAttacking = false;
    }

    // Update is called once per frame
    void Update()
    {
        Attack();
    }

    private void FixedUpdate()
    {

    }

    public void Attack()
    {


        if (UIController.Instant.attacking || Input.GetKeyDown(KeyCode.K))
        {
            //if (isAttacking == true)
            //{
            //    return;
            //}

            if (atkTimer > 0)
            {
                return;
            }
            atkTimer = atkSpeed;

            SoundManager.Instant?.PlaySound("dagger-woosh");
            isAttacking = true;
        }

        if (atkTimer <= 0)
        {
            isAttacking = false;
            return;
        }

        atkTimer -= Time.fixedDeltaTime;
    }

}
