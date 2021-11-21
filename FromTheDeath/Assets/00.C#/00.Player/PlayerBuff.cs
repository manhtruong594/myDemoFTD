using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBuff : Singleton<PlayerBuff>
{


    public void HPBuff(int HPmount)
    {
        PlayerController.Instant.maxHP += HPmount;
        PlayerController.Instant.HP += HPmount;
        UIController.Instant.playerHealth.maxValue = PlayerController.Instant.maxHP;
    }


    public void PowerBuff(int dame)
    {
        PlayerController.Instant.damage += dame;
    }


    public void HPRegen(int amount)
    {
        PlayerController.Instant.HP += amount;
    }
}
