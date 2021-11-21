using System.Collections;
using UnityEngine;

public class PlayerGetDmg : Singleton<PlayerGetDmg>
{
    [SerializeField] bool isInvulnerable;
    [SerializeField] float invulnerableTime;
    Color originColor;
    SpriteRenderer rend;
    public bool isDying;



    // Start is called before the first frame update
    void Start()
    {
        isInvulnerable = false;
        isDying = false;
        rend = this.GetComponentInChildren<SpriteRenderer>();
        originColor = this.rend.color;
    }


    // Update is called once per frame
    void Update()
    {

    }


    public void GetDmg(int dmg, float stunTime)
    {
        PlayerController.Instant.HP -= dmg;
        SoundManager.Instant.PlaySound("ow");

        if (!PlayerController.Instant.canControll)
            return;

        PlayerController.Instant.canControll = false;
        StartCoroutine(ExitStunState(stunTime));
    }

    IEnumerator ExitStunState(float stuntime)
    {
        yield return new WaitForSeconds(stuntime);
        PlayerController.Instant.canControll = true;
    }




    public void Invulnerable()
    {
        originColor.a = 0.5f;
        this.rend.color = originColor;

        gameObject.layer = 11;

        if (isInvulnerable)
            return;


        isInvulnerable = true;
        StartCoroutine(ExitInvulnerableState(invulnerableTime));
    }

    IEnumerator ExitInvulnerableState(float time)
    {
        yield return new WaitForSeconds(time);
        isInvulnerable = false;

        originColor.a = 1;
        this.rend.color = originColor;

        gameObject.layer = 8;
        gameObject.tag = "Player";
    }



    public void Death()
    {
        if (isDying == true)
            return;
        isDying = true;
        StartCoroutine(ExitDyingState());

    }

    IEnumerator ExitDyingState()
    {
        yield return new WaitForSeconds(1.5f);
        isDying = false;
        gameObject.SetActive(false);
        GameManager.Instant.GameOver();
    }


}
