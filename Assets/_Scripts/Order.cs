using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Order : MonoBehaviour
{
    private string orderType;
    private string orderPurpose;

    public string OrderType
    {
        get { return orderType; }
    }
    public string OrderPurpose
    {
        get { return orderPurpose; }
        set { orderPurpose = value; }
    }
    
    Potion potion;

    public string[] orderPurposeList = new string[]
    {
        "Delivery",
        "Personal",
        "Alchemy",
        "Apothecary",
        "Wizardry"
    };

    // Constructor
    public Order(string sOrderType)
    {
        orderType = sOrderType;

        SetOrderPurpose();
    }

    private void SetOrderPurpose()
    {
        if(!orderType.Equals("OTC"))
        {
            orderPurpose = orderPurposeList[(int)Random.Range(0, orderPurposeList.Length)];
            Debug.Log("Order purpose: " + orderPurpose);
        }
    }
}
