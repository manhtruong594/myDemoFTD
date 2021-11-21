using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIShopCoinItems : ShopManager
{
    public int price;
    [SerializeField] int buffIndex;


    [SerializeField] Text priceTxt;


    private void OnEnable()
    {
        SetPrice();
        PriceDisplay();

    }

    
    public void SetPrice()
    {

        foreach (var item in CoinItems)
        {
            if(this.gameObject.name == item.Key)
            {
                this.price = item.Value;
            }
        }

    }

    public void OnPurchase(int buffAmount)
    {
        if (this.price <= GameManager.Instant.coinCount)
        {
            GameManager.Instant.DecreaseCoin(price);
            this.gameObject.SetActive(false);
            AfterPurchase(buffAmount);
        }
        else
        {
            ActiveNotice();
        }


    }


    public void PriceDisplay()
    {
        priceTxt.text = $"{this.gameObject.name} \n {price} Coins";

    }

    public void AfterPurchase( int amount)
    {
        if (buffIndex ==1)
        {
            PlayerBuff.Instant.HPBuff(amount);
        }
        else if (buffIndex ==2)
        {
            PlayerBuff.Instant.PowerBuff(amount);
        }
    }

}
