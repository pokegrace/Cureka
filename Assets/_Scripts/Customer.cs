using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Customer : MonoBehaviour
{
    private string classType;
    private string customerName;
    private Order customerOrder;

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
