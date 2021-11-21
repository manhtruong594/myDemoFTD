using UnityEngine;

public class PlayerController : Singleton<PlayerController>
{
    [SerializeField] int speed;
    [SerializeField] int jumpForce;
    public int HP;
    public int damage;
    public int pushForce;
    public int maxHP = 200;

    Vector2 movenent;
    public Vector2 joyVector;
    Vector2 localScale;
    public bool onGround;
    public bool canControll;

    Rigidbody2D rigi;


    void Start()
    {
        rigi = this.GetComponent<Rigidbody2D>();
        canControll = true;
        HP = maxHP;
    }


    private void FixedUpdate()
    {
        if (HP <= 0)
        {
            PlayerGetDmg.Instant.Death();
            return;
        }

        if (HP > maxHP)
        {
            HP = maxHP;
        }

        onGround = GroundCheck.Instant.isGround;
        joyVector = JoystickButton.Instant.MovingVector();
        Moving();
    }


    public void Moving()
    {
        if (!canControll)
            return;
        ChangeLocalScale();


        movenent.x = joyVector.x * speed * Time.fixedDeltaTime;
        movenent.y = rigi.velocity.y;


        if (UIController.Instant.jumping || Input.GetKeyDown(KeyCode.J))
        {
            if (!onGround)
                return;
            SoundManager.Instant?.PlaySound("jump");
            UIController.Instant.SetJumping(false);

            this.rigi.AddForce(Vector2.up * jumpForce);
            onGround = false;
        }

        this.rigi.velocity = movenent;
    }


    //public bool GroundCheck()
    //{
    //    float lenRay = 0.2f;

    //    RaycastHit2D[] rays = Physics2D.BoxCastAll(colli.bounds.center, colli.bounds.size, 0f, Vector2.down, lenRay);

    //    foreach (RaycastHit2D r in rays)
    //    {
    //        if (r.collider.CompareTag("Ground"))
    //        {
    //            return true;
    //        }
    //    }
    //    return false;
    //}


    public void ChangeLocalScale()
    {
        localScale = this.transform.localScale;

        if (movenent.x < 0)
            localScale.x = -1;

        else if (movenent.x > 0)
            localScale.x = 1;

        this.transform.localScale = localScale;
    }



}





