using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrderAssigner : MonoBehaviour
{
    // lists of names/classes
    public static List<string> classList = new List<string>(new string[]
    {
        "Courier",
        "Lackey",
        "Adventurer",
        "Alchemist",
        "Sorcerer",
        "Herbalist",
        "Shaman",
        "Wizard"
    });

    public static List<string> nameList = new List<string>(new string[]
    {
        "Helena",
        "Cordon",
        "Seilia",
        "Grendil",
        "Eldris",
        "Mervin",
        "Ariel"
    });

    // arrays of potions
    public static Potion[] OTCPotions = new Potion[]
    {
        new HealthPotion(),
        new GreaterHealthPotion()
    };
    public static Potion[] PrescriptionPotions = new Potion[]
    {
        new PolymorphicPotion(),
        new LemonWater()
    };

    // sets order to OTC or Prescription
    public static string SetOrderType()
    {
        int r = Random.Range(0, 10);
        if (r < 4)
            return "OTC";
        else
            return "Prescription";
    }

    // decides if customer has prescription form or not
    public static void GiveSpecialForm(Customer customer)
    {
        if (customer.CustomerOrder.OrderType.Equals("Prescription"))
        {
            int r = Random.Range(0, 4);
            if (r <= 2)
                customer.hasSpecialForm = true;
            else
                customer.hasSpecialForm = false;

            Debug.Log("has special form: " + customer.hasSpecialForm);
        }
    }

    // Sets the order purpose based on class
    public static string SetOrderPurpose(Order order, string classType)
    {
        if (classType.Equals("Lackey") || classType.Equals("Adventurer"))
        {
            if (order.OrderType.Equals("OTC"))
                return "Personal";
            else
            {
                int r = (int)Random.Range(0, 3);
                if (r < 1)
                    return "Personal";
                else
                    return "Delivery";
            }
        }
        else if (classType.Equals("Alchemist") || classType.Equals("Herbalist") || classType.Equals("Shaman"))
        {
            if (order.OrderType.Equals("OTC"))
                return "Personal";
            else
            {
                int r = (int)Random.Range(0, 3);
                if (r == 0)
                    return "Alchemy";
                else if (r == 1)
                    return "Apothecary";
                else
                    return "Personal";
            }
        }
        else
        {
            if (order.OrderType.Equals("OTC"))
                return "Personal";
            else
            {
                int r = (int)Random.Range(0, 3);
                if (r < 1)
                    return "Personal";
                else
                    return "Wizardry";
            }
        }
    }

    // assigns potion to order
    public static Potion SetOrderPotion(string orderType)
    {
        if (orderType.Equals("OTC"))
           return OTCPotions[(int)Random.Range(0, OTCPotions.Length)];
        else
            return PrescriptionPotions[(int)Random.Range(0, PrescriptionPotions.Length)];
    }
}
