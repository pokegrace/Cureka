using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Order : MonoBehaviour
{
    private string orderType;
    private string orderPurpose;
    private Potion orderPotion;

    // getters and setters
    public string OrderType
    {
        get { return orderType; }
    }
    public string OrderPurpose
    {
        get { return orderPurpose; }
    }
    public Potion OrderPotion
    {
        get { return orderPotion; }
    }

    // Constructor
    public Order(string classType)
    {
        orderType = OrderAssigner.SetOrderType();
        orderPurpose = OrderAssigner.SetOrderPurpose(this, classType);
        orderPotion = OrderAssigner.SetOrderPotion(orderType);
    }
}
