using UnityEngine;

public class EnemyAnimation : AnimationController
{
    Animator anim;
    [SerializeField] EnemyState eState;
    EnemyController enemy;

    private void Awake()
    {

    }

    // Start is called before the first frame update
    void Start()
    {
        anim = this.GetComponent<Animator>();
        enemy = this.GetComponent<EnemyController>();
    }

    // Update is called once per frame
    void Update()
    {

        for (int i = 0; i < (int)EnemyState.len; i++)
        {
            EnemyState thisState = (EnemyState)i;

            if (thisState == eState)
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
        if (enemy.isDying)
            eState = EnemyState.Death;

        else if (enemy.isHurting)
            eState = EnemyState.Hurt;

        else if (enemy.rigi.velocity != Vector2.zero)
        {
            eState = EnemyState.Attack;
        }
        else
            eState = EnemyState.Idle;

    }

}


