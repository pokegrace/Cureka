using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Customer : MonoBehaviour
{
    private string classType;
    private string customerName;
    private Order customerOrder;

    public bool hasSpecialForm;

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

    // lists of names/classes
    public List<string> classList = new List<string>(new string[]
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
    public List<string> nameList = new List<string>(new string[]
    {
        "Helena",
        "Cordon",
        "Seilia",
        "Grendil",
        "Eldris"
    });

    // create a random order depending on customer class type
    public void CreateOrder()
    {
        customerOrder = new Order(this.ClassType);
    }
}
