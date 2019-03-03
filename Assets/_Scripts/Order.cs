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
    public Order(string classType)
    {
        // randomizing order type
        int r = (int)Random.Range(0, 2);
        if (r == 0)
            orderType = "OTC";
        else
            orderType = "Prescription";

        SetOrderPurpose(classType);
        SetOrderPotion();
    }

    private void SetOrderPurpose(string classType)
    {
        #region lackey_adventurer
        if (classType.Equals("Lackey") || classType.Equals("Adventurer"))
        {
            if (orderType.Equals("OTC"))
                orderPurpose = "Personal";
            else
            {
                int r = (int)Random.Range(0, 2);
                if (r == 0)
                    orderPurpose = "Personal";
                else
                    orderPurpose = "Delivery";
            }
        }
        #endregion
        #region alchemist_herbalist_shaman
        else if (classType.Equals("Alchemist") || classType.Equals("Herbalist") || classType.Equals("Shaman"))
        {
            if (orderType.Equals("OTC"))
                orderPurpose = "Personal";
            else
            {
                int r = (int)Random.Range(0, 3);
                if (r == 0)
                    orderPurpose = "Alchemy";
                else if (r == 1)
                    orderPurpose = "Apothecary";
                else
                    orderPurpose = "Personal";
            }
        }
        #endregion
        #region wizard
        else
        {
            if (orderType.Equals("OTC"))
                orderPurpose = "Personal";
            else
            {
                int r = (int)Random.Range(0, 2);
                if (r == 0)
                    orderPurpose = "Personal";
                else
                    orderPurpose = "Wizardry";
            }
        }
        #endregion
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
