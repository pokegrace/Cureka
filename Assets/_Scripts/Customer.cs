using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Customer : MonoBehaviour
{
    private string species;
    private string customerName;
    private Order order;

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
    public Order Order
    {
        get { return order; }
        set { order = value; }
    }

    public void CreateOrder()
    {
        if (species.Equals("Courier") || species.Equals("Lackey") || species.Equals("Adventurer"))
        {
            Order = new Order("OTC");
        }
        else
        {
            Order = new Order("Prescription");
        }
    }
}
