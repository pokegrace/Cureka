using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Customer : MonoBehaviour
{
    private string species;
    private string customerName;
    private Order customerOrder;

    public string CustomerName
    {
        get { return customerName; }
        set { customerName = value; }
    }
    public string Species
    {
        get { return species; }
        set { species = value; }
    }
    public Order CustomerOrder
    {
        get { return customerOrder; }
        set { customerOrder = value; }
    }

    public void CreateOrder()
    {
        if (species.Equals("Courier") || species.Equals("Lackey") || species.Equals("Adventurer"))
        {
            customerOrder = new Order("OTC");
        }
        else
        {
            customerOrder = new Order("Prescription");
        }
    }
}
