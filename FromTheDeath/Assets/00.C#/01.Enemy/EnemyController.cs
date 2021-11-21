using System.Collections;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField] protected int detectRange;
    protected int currentHP;
    public EnemyTableObject enemyData;

    public GameObject canSubdueEffect;
    protected GameObject target;
    public GameObject childEffect;
    [SerializeField] GameObject coinParticle;
    public Rigidbody2D rigi;
    protected Rigidbody2D playerRigi;
    //protected LineRenderer detectLine;

    public bool canSubdue;
    public bool isDying;
    public bool isHurting;
    int coinReward;
    

    protected void GetReference()
    {
        isDying = false;
        isHurting = false;
        //detectLine = this.GetComponent<LineRenderer>();
        rigi = this.GetComponent<Rigidbody2D>();
        playerRigi = PlayerController.Instant.GetComponent<Rigidbody2D>();
    }


    //add canSubdueEffect into enemy --------------------
    protected void AddEffect()
    {
        if (!canSubdue)
        {
            childEffect = null;
            return;
        }

        if (childEffect)
        {
            childEffect.SetActive(true);
            return;
        }

        childEffect = Instantiate(canSubdueEffect, this.transform.position, Quaternion.identity);
        childEffect.transform.parent = this.transform;
        childEffect.transform.localPosition = new Vector3(0, 0.5f, 0);

    }



    // interact --------------------------------------
    protected virtual void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.CompareTag("AtkRange"))
        {
            GetDmg(collision.gameObject);
        }

        else if (collision.CompareTag("Player"))
        {
            ColliPlayer(collision.gameObject);
        }
    }

    protected virtual void GetDmg(GameObject player)
    {

        SoundManager.Instant.PlaySound("cutting");
    }


    protected void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.CompareTag("Player"))
            ColliPlayer(collision.gameObject);

        else if (collision.gameObject.CompareTag("Hechman"))
            GetDmgH(collision.gameObject);

    }
    protected virtual void ColliPlayer(GameObject player)
    {

    }

    protected virtual void GetDmgH(GameObject hechman)
    {
        currentHP -= HechmanController.Instant.Dmg;

        rigi.velocity = Vector2.zero;
        rigi.AddForce((hechman.transform.position - this.transform.position).normalized * -HechmanController.Instant.pushForce);
        SoundManager.Instant.PlaySound("beast");
    }


    // Death -------------------------------------------------
    protected virtual void Death()
    {
        if (isDying == true)
            return;
        this.gameObject.layer = 11;             // body layer
        isDying = true;
        this.target = null;

        AfterDeath();

        if (!canSubdue)
        {
            StartCoroutine(ExitDyingState1());
            return;
        }

        StartCoroutine(ExitDyingState2());

    }
    IEnumerator ExitDyingState1()
    {
        yield return new WaitForSeconds(1.5f);
        isDying = false;
        this.gameObject.layer = 9;              // back to enemy layer
        gameObject.SetActive(false);

    }
    IEnumerator ExitDyingState2()
    {
        yield return new WaitForSeconds(5f);
        isDying = false;
        this.gameObject.layer = 9;              // back to enemy layer
        gameObject.SetActive(false);

    }


    protected void AfterDeath()
    {
        coinReward = Random.Range(6, 10);
        GameManager.Instant.IncreaseCoin(coinReward);
        GameObject CoinParticle = Instantiate(coinParticle, this.transform.position, Quaternion.identity);
        SoundManager.Instant.PlaySound("gold-coin-prize");
    }


    // Detect and direction ---------------------------------------
    protected void DetectTarget()
    {
        if (PlayerController.Instant.gameObject == null)
            return;
        if (Vector2.Distance(this.transform.position, PlayerController.Instant.transform.position) > detectRange)
        {
            target = null;
            //detectLine.enabled = false;
            return;
        }

        target = PlayerController.Instant.gameObject;
        //detectLine.SetPosition(0, this.transform.position);
        //detectLine.SetPosition(1, target.transform.position);
        //detectLine.enabled = true;
    }



    // enemy faces towards player
    protected void FaceDirection()
    {
        Vector2 faceDir = this.transform.localScale;
        Vector2 dir = PlayerController.Instant.transform.position - this.transform.position;

        if (dir.x < 0)
        {
            faceDir.x = -1;
            this.transform.localScale = faceDir;
            return;
        }
        else if (dir.x > 0)
        {
            faceDir.x = 1;
            this.transform.localScale = faceDir;
        }

    }




}
