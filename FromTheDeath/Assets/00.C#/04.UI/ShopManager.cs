using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopManager : MonoBehaviour
{

    public Dictionary<string, int> CoinItems = new Dictionary<string, int>();

    public Dictionary<string, int> SoulItems = new Dictionary<string, int>();

    [SerializeField] protected GameObject NotEnoughMoneyTxt;

    public void Awake()
    {
        CoinItems.Add(CoinItemManager.name1, CoinItemManager.price1);
        CoinItems.Add(CoinItemManager.name2, CoinItemManager.price2);
        SoulItems.Add(SoulItemManager.name1, SoulItemManager.price1);

        NotEnoughMoneyTxt = UIController.Instant.shopNoticeTxt;
    }


    public void ActiveNotice()
    {
        if (NotEnoughMoneyTxt.activeSelf)
        {
            return;
        }
        NotEnoughMoneyTxt.SetActive(true);
        StartCoroutine(DeactiveNotice());
    }
   
    IEnumerator DeactiveNotice()
    {
        yield return new WaitForSeconds(0.5f);
        NotEnoughMoneyTxt.SetActive(false);
    }

}
