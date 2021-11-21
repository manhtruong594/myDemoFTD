using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIShopSoulItems : ShopManager
{
    public int price;

    Button btn;

    [SerializeField] Text priceTxt;

    private void OnEnable()
    {
        btn = this.GetComponent<Button>();

        btn.onClick.AddListener(this.OnPurchase);
        SetPrice();
        PriceDisplay();
    }

   
    public void SetPrice()
    {

        foreach (var item in SoulItems)
        {
            if (this.gameObject.name == item.Key)
            {
                this.price = item.Value;
            }
        }

    }

    public void OnPurchase()
    {
        if (this.price <= GameManager.Instant.soulCount)
        {
            this.gameObject.SetActive(false);
            AfterPurchase();
        }
        else
        {
            ActiveNotice();
        }


    }


    public void PriceDisplay()
    {
        priceTxt.text = $"{price} Souls";

    }

    public void AfterPurchase()
    {
        HechmanUI.Instant.LoadHechmanBat();
    }



}
