using UnityEngine;

public class PlayerAnimation : AnimationController
{
    Animator anim;
    public PlayerState pState;


    // Start is called before the first frame update
    void Start()
    {
        anim = this.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < (int)AnimationController.PlayerState.len; i++)
        {
            PlayerState thisState = (PlayerState)i;

            if (pState == thisState)
                anim.SetBool(thisState.ToString(), true);
            else
                anim.SetBool(thisState.ToString(), false);
        }

        ChangeAnim();

    }



    public void ChangeAnim()
    {
        if (PlayerGetDmg.Instant.isDying)
            pState = PlayerState.Death;

        else if (!PlayerController.Instant.canControll)
            pState = PlayerState.TakeHit;

        else if (PlayerAttack.Instant.isAttacking == true)
        {
            pState = PlayerState.Attack1;
        }

        else if (!PlayerController.Instant.onGround)
        {
            pState = PlayerState.Jump;
        }

        else if (PlayerController.Instant.onGround == true && PlayerAttack.Instant.isAttacking == false)
        {
            if (PlayerController.Instant.joyVector.x != 0)
                pState = PlayerState.Run;
            else
                pState = PlayerState.Idle;
        }

    }

}
