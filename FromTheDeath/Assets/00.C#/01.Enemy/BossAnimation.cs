using UnityEngine;

public class BossAnimation : AnimationController
{
    Animator anim;
    [SerializeField] BossState bState;
    BossController boss;

    private void Awake()
    {

    }

    // Start is called before the first frame update
    void Start()
    {
        anim = this.GetComponent<Animator>();
        boss = this.GetComponent<BossController>();
    }

    // Update is called once per frame
    void Update()
    {

        for (int i = 0; i < (int)BossState.len; i++)
        {
            BossState thisState = (BossState)i;

            if (thisState == bState)
            {
                anim.SetBool(thisState.ToString(), true);
            }
            else
                anim.SetBool(thisState.ToString(), false);

        }


        ChangeAnim();
    }


    public void ChangeAnim()
    {
        if (boss.isDying)
            bState = BossState.Death;
        else if (boss.isAttacking)
            bState = BossState.Attack;
        else if (boss.isCasting)
            bState = BossState.Cast;
        else if (boss.isHurting)
            bState = BossState.Hurt;
       
        else if (boss.rigi.velocity != Vector2.zero)
        {
            bState = BossState.Walk;
        }
        else
            bState = BossState.Idle;

    }

}