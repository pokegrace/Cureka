using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIHandler : MonoBehaviour
{
    private bool panelActive = false;
    private Customer customer;

    private GameObject orderPanel;
    private Button closeButton;
    private Text customerName;
    private Text customerClass;
    private Text orderType;
    private Text potionName;
    private Text orderPurpose;
    private Text price;

    private void Start()
    {
        orderPanel = GameObject.FindGameObjectWithTag("Canvas").transform.GetChild(1).gameObject;

        closeButton = orderPanel.transform.GetChild(7).GetComponent<Button>();
        closeButton.onClick.AddListener(() => SetPanelActive());

        customerName = orderPanel.transform.GetChild(1).GetComponent<Text>();
        customerClass = orderPanel.transform.GetChild(2).GetComponent<Text>();
        orderType = orderPanel.transform.GetChild(3).GetComponent<Text>();
        potionName = orderPanel.transform.GetChild(4).GetComponent<Text>();
        orderPurpose = orderPanel.transform.GetChild(5).GetComponent<Text>();
        price = orderPanel.transform.GetChild(6).GetComponent<Text>();
    }

    public void SetPanelActive()
    {
        customer = GameObject.Find("Customer").GetComponent<Customer>();

        if (!panelActive)
        {
            orderPanel.SetActive(true);
            SetPanelText();
            panelActive = true;
        }
        else
        {
            orderPanel.SetActive(false);
            panelActive = false;
        }
    }

    private void SetPanelText()
    {
        customerName.text = "Name: " + customer.CustomerName;
        customerClass.text = "Class: " + customer.ClassType;
        orderType.text = "Order Type: " + customer.CustomerOrder.OrderType;
        potionName.text = "Potion: " + customer.CustomerOrder.OrderPotion.PotionName;
        orderPurpose.text = "Order Purpose: " + customer.CustomerOrder.OrderPurpose;
        price.text = "Price: " + customer.CustomerOrder.OrderPotion.price.ToString() + "g";
    }
}
