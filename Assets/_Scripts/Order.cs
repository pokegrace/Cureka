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

    // array of order purposes
    private string[] orderPurposeList = new string[]
    {
        "Delivery",
        "Personal",
        "Alchemy",
        "Apothecary",
        "Wizardry"
    };

    // arrays of potions
    private Potion[] OTCPotions = new Potion[]
    {
        new HealthPotion(),
        new GreaterHealthPotion()
    };
    private Potion[] PrescriptionPotions = new Potion[]
    {
        new PolymorphicPotion(),
        new LemonWater()
    };

    // Constructor
    public Order(string sOrderType)
    {
        orderType = sOrderType;

        SetOrderPurpose();
        SetOrderPotion();
    }

    // for OTC, purpose is personal. for presc, purpose is random.
    private void SetOrderPurpose()
    {
        if(orderType.Equals("OTC"))
            orderPurpose = "Personal";
        else
            orderPurpose = orderPurposeList[(int)Random.Range(0, orderPurposeList.Length)];
    }

    // create random potion for either OTC or presc order
    private void SetOrderPotion()
    {
        if(orderType.Equals("OTC"))
            orderPotion = OTCPotions[(int)Random.Range(0, OTCPotions.Length)];
        else
            orderPotion = PrescriptionPotions[(int)Random.Range(0, PrescriptionPotions.Length)];
    }
}
