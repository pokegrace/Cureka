using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Customer : MonoBehaviour
{
    private string classType;
    private string customerName;
    private Order customerOrder;

    // getters and setters
    public string CustomerName
    {
        get { return customerName; }
        set { customerName = value; }
    }
    public string ClassType
    {
        get { return classType; }
        set { classType = value; }
    }
    public Order CustomerOrder
    {
        get { return customerOrder; }
        set { customerOrder = value; }
    }

    // arrays of names/classes
    public string[] classList = new string[]
    {
        "Courier",
        "Lackey",
        "Adventurer",
        "Alchemist",
        "Sorcerer",
        "Herbalist",
        "Shaman",
        "Wizard"
    };
    public string[] nameList = new string[]
    {
        "Tim",
        "Bill",
        "Nelly",
        "Mina",
        "Eldritch Mystifier"
    };

    // create a random order depending on customer class type
    public void CreateOrder()
    {
        if (classType.Equals("Courier") || classType.Equals("Lackey") || classType.Equals("Adventurer"))
        {
            customerOrder = new Order("OTC");
        }
        else
        {
            customerOrder = new Order("Prescription");
        }
    }
}
