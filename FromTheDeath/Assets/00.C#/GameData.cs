using UnityEngine;

[System.Serializable]
public class GameData 
{
    public int coins;
    public int souls;
    public Vector3 playerPosition;

    public int sceneIndex;
}


public static class CoinItemManager
{
    public static int itemCount = 2;

    public static string name1 = "HpPower"; public static int price1 = 50;

    public static string name2 = "DamagePower"; public static int price2 = 70;

}

public static class SoulItemManager
{
    public static string name1 = "BatHm"; public static int price1 = 10;


}



