using System.Collections;
using UnityEngine;

public class HechmanController : Singleton<HechmanController>
{

    public int HP, Dmg, pushForce, maxHP;

    public GameObject target;
    public Rigidbody2D rigi;

    public bool isDying;


    protected void GetReference()
    {
        isDying = false;
        HP = maxHP;
        rigi = this.GetComponent<Rigidbody2D>();
    }

    protected void OnTriggerStay2D(Collider2D collision)
    {
        if (target)
            return;

        if (collision.CompareTag("Enemy"))
        {
            target = collision.gameObject;
        }
    }

    protected void OnTriggerExit2D(Collider2D collision)
    {
        if (target == null)
        {
            return;
        }

        if (collision.gameObject == this.target)
        {
            target = null;
        }

    }



    protected void OnCollisionEnter2D(Collision2D collision)
    {

        if (!collision.gameObject.CompareTag("Enemy"))
        {
            return;
        }
        ColliEnemy(collision.gameObject);
        GetDmg(collision.gameObject);
    }
    protected virtual void ColliEnemy(GameObject enemy)
    {

    }
    protected virtual void GetDmg(GameObject enemy)
    {

    }



    public void Death()
    {
        if (isDying == true)
            return;
        this.gameObject.layer = 11;             // god layer
        isDying = true;
        StartCoroutine(ExitDyingState());
    }
    IEnumerator ExitDyingState()
    {
        yield return new WaitForSeconds(1.5f);
        isDying = false;
        this.gameObject.layer = 13;              // back to hecman layer
        Destroy(this.gameObject);
        HechmanUI.Instant.healthBar.gameObject.SetActive(false);

    }



    // hechman faces towards enemy
    protected void FaceDirection()
    {
        Vector2 faceDir = this.transform.localScale;

        if (!target)
        {
            faceDir.x = -PlayerController.Instant.transform.localScale.x;
            this.transform.localScale = faceDir;
            return;
        }


        Vector2 dir = target.transform.position - this.transform.position;

        if (dir.x < 0)
        {
            faceDir.x = 1;
        }
        else if (dir.x > 0)
        {
            faceDir.x = -1;
        }

        this.transform.localScale = faceDir;
    }


}
