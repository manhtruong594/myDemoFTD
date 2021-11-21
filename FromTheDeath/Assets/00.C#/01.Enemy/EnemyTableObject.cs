using UnityEngine;

[CreateAssetMenu(fileName = "EnemyData", menuName = "GameData/EnemyData")]
public class EnemyTableObject : ScriptableObject
{
    public int damage;
    public int maxHP;
    public float atkSpeed;
    public int speed;
    public float stunTime;
    public int pushForce;

    public int bossdmg;
    public int bossMaxHP;
    

}




