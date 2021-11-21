using UnityEngine;

public class HechmanBat : HechmanController
{
    [SerializeField] EnemyTableObject enemyData;

    [SerializeField] float atkSpeed; float timerAtk;
    [SerializeField] int speed;
    Collider2D colli;

    private void Reset()
    {
        maxHP = 1000;
        pushForce = 150;
        Dmg = 40;
        speed = 200;
        atkSpeed = 1.8f;
    }

    private void Awake()
    {
        GetReference();
        colli = this.GetComponent<Collider2D>();
    }

    // Start is called before the first frame update
    void Start()
    {
        timerAtk = atkSpeed;
        Physics2D.IgnoreCollision(colli, PlayerController.Instant.GetComponent<Collider2D>());
    }



    private void FixedUpdate()
    {
        FaceDirection();

        if (this.HP <= 0)
        {
            Death();
            return;
        }

        if (target && !target.activeSelf)
        {
            target = null;
            return;
        }

        Attack();

    }


    protected override void ColliEnemy(GameObject enemy)
    {

        base.ColliEnemy(enemy);

    }


    public void Attack()
    {
        if (target == null)
            return;
        timerAtk -= Time.fixedDeltaTime;

        if (timerAtk >= 0)
            return;

        rigi.AddForce((target.transform.position - this.transform.position).normalized * speed);
        timerAtk = atkSpeed;

    }



    protected override void GetDmg(GameObject enemy)
    {
        base.GetDmg(enemy);
        this.HP -= enemyData.damage;

        rigi.velocity = Vector2.zero;

    }

}
