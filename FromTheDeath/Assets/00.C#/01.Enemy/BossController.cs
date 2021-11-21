using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossController : EnemyController
{
    [SerializeField] int actionTimer;
    [SerializeField] int actionIndex;
    [SerializeField] int maxCreepCount;
    public bool isAttacking;
    public bool isCasting;

    [SerializeField] Transform spawnCreep;
    [SerializeField] GameObject thornParent;
    [SerializeField] Slider BossHpBar;
    [SerializeField] List<GameObject> creeps = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        currentHP = enemyData.bossMaxHP;
        GetReference();
        RandomAction();
        BossHpBar.maxValue = enemyData.bossMaxHP;
        BossHpBar.minValue = 0;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (currentHP <= 0)
        {
            Death();
            return;
        }
        Moving();
        FaceDirection();
        BossHpBar.value = currentHP;
    }


    void Moving()
    {
        rigi.velocity = new Vector3(this.transform.localScale.x, rigi.velocity.y);
    }

     

    void RandomAction()
    {
        actionIndex = Random.Range(1, 4);                 ////testt////
        actionTimer = Random.Range(4, 7);
        StartCoroutine(DelayCast(actionTimer));
    }


    IEnumerator DelayCast(int castSpeed)
    {
        yield return new WaitForSeconds(castSpeed);

        if (actionIndex == 1)
        {
            isAttacking = true;
            Debug.Log("attack");
        }

        else if (actionIndex == 2)
        {
            isCasting = true;
        }

        else if (actionIndex == 3)
        {
            isCasting = true;
        }

        Invoke("SetFalseState", 0.5f);
        Invoke("RandomAction", 1f);
        
    }

    void SetFalseState()
    {
        if (actionIndex ==2)
        {
            Cast1();
            isCasting = false;
        }

        else if(actionIndex == 3)
        {
            Cast2();
            isCasting = false;
        }
        else
        {
            SoundManager.Instant.PlaySound("boss-slice");
            isAttacking = false;
        }
    }


    
    void Cast1()
    {
        Debug.Log("cast 1");
        SpawnCreep();
    }
    void Cast2()
    {
        Debug.Log("cast 2");
        SoundManager.Instant.PlaySound("boss-cast-thorn");
        CameraMoving.Instant.StartShake(0.4f, 0.1f); 
        thornParent.SetActive(true);
    }


    void SpawnCreep()
    {
        GameObject creep = ObjectPooling.Instant.GetBat(maxCreepCount,creeps);

        creep.transform.position = spawnCreep.position;
        Vector2 startMove = PlayerController.Instant.transform.position - spawnCreep.position;
        creep.GetComponent<Rigidbody2D>().AddForce(startMove * 6);
        creep.SetActive(true);

    }


    // interact --------------------

    protected override void ColliPlayer(GameObject player)
    {
        base.ColliPlayer(player);
        PlayerGetDmg.Instant.GetDmg(enemyData.bossdmg, enemyData.stunTime);
        PlayerGetDmg.Instant.Invulnerable();

        playerRigi.velocity = Vector2.zero;
        playerRigi.AddForce((player.transform.position - this.transform.position).normalized * enemyData.pushForce);
    }

    
    protected override void GetDmg(GameObject player)
    {
        base.GetDmg(player);
        isHurting = true;
        gameObject.layer = 11;

        currentHP -= PlayerController.Instant.damage;

        rigi.velocity = Vector2.zero;
        rigi.AddForce((player.transform.position - this.transform.position).normalized * -PlayerController.Instant.pushForce);

        StartCoroutine(ExitGetDmgState());
    }

    IEnumerator ExitGetDmgState()
    {
        yield return new WaitForSeconds(1.5f);
        isHurting = false;
        gameObject.layer = 9;

    }

    protected override void Death()
    {
        base.Death();
        SoundManager.Instant.PlaySound("boss-death");
        StartCoroutine(WaitEndGame());
    }
    
    IEnumerator WaitEndGame()
    {
        yield return new WaitForSeconds(1);
        GameManager.Instant.GameFinish();
    }
}
