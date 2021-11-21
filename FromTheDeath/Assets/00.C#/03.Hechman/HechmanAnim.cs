using UnityEngine;

public class HechmanAnim : AnimationController
{
    Animator anim;
    [SerializeField] EnemyState eState;
    HechmanController hechman;

    private void Awake()
    {

    }

    // Start is called before the first frame update
    void Start()
    {
        anim = this.GetComponent<Animator>();
        hechman = this.GetComponent<HechmanController>();
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
        if (hechman.isDying)
            eState = EnemyState.Death;

        else if (!hechman.target)
        {
            eState = EnemyState.Walk;
        }

        else
            eState = EnemyState.Attack;
    }

}
