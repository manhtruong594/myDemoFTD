using System.Collections;
using UnityEngine;

public class EnemyBat : EnemyController
{
    float timerAtk;

    private void OnEnable()
    {
        GetReference();
        currentHP = enemyData.maxHP;
        timerAtk = enemyData.atkSpeed;
        AddEffect();
    }

    private void Awake()
    {

    }

    // Start is called before the first frame update
    void Start()
    {
        
    }



    private void FixedUpdate()
    {
        if (currentHP <= 0)
        {
            Death();
            return;
        }

        DetectTarget();
        Attack();

        FaceDirection();
    }



    protected override void ColliPlayer(GameObject player)
    {
        base.ColliPlayer(player);
        rigi.velocity = Vector2.zero;

        PlayerGetDmg.Instant.GetDmg(enemyData.damage, enemyData.stunTime);
        PlayerGetDmg.Instant.Invulnerable();

        playerRigi.velocity = Vector2.zero;
        playerRigi.AddForce((player.transform.position - this.transform.position).normalized * enemyData.pushForce);

    }


    public void Attack()
    {
        if (target == null)
            return;
        timerAtk -= Time.fixedDeltaTime;

        if (timerAtk >= 0)
        {
            return;
        }

        rigi.AddForce((target.transform.position - this.transform.position).normalized * enemyData.speed * 3);
        timerAtk = enemyData.atkSpeed;

    }



    protected override void GetDmg(GameObject player)
    {
        base.GetDmg(player);
        isHurting = true;
        currentHP -= PlayerController.Instant.damage;

        rigi.velocity = Vector2.zero;
        rigi.AddForce((player.transform.position - this.transform.position).normalized * -PlayerController.Instant.pushForce);

        timerAtk = enemyData.atkSpeed;
        StartCoroutine(ExitGetDmgState());

    }

    IEnumerator ExitGetDmgState()
    {
        yield return new WaitForSeconds(1.5f);
        isHurting = false;
    }

    protected override void GetDmgH(GameObject hechman)
    {
        base.GetDmgH(hechman);
        isHurting = true;
        StartCoroutine(ExitGetDmgState());
    }

    protected override void Death()
    {
        base.Death();
    }

}
