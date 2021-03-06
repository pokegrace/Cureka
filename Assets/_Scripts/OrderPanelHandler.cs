﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OrderPanelHandler : MonoBehaviour
{
    public bool panelActive = false;
    private Customer customer;

    private GameObject orderPanel;
    private Button closeButton;
    private Text customerName;
    private Text customerClass;
    private Text orderType;
    private Text potionName;
    private Text orderPurpose;
    private Text price;

    // finding all references
    private void Start()
    {
        orderPanel = GameObject.FindGameObjectWithTag("Canvas").transform.Find("Order Form").gameObject;

        closeButton = orderPanel.transform.GetChild(7).GetComponent<Button>();
        closeButton.onClick.AddListener(() => OpenClosePanel());

        customerName = orderPanel.transform.GetChild(1).GetComponent<Text>();
        customerClass = orderPanel.transform.GetChild(2).GetComponent<Text>();
        orderType = orderPanel.transform.GetChild(3).GetComponent<Text>();
        potionName = orderPanel.transform.GetChild(4).GetComponent<Text>();
        orderPurpose = orderPanel.transform.GetChild(5).GetComponent<Text>();
        price = orderPanel.transform.GetChild(6).GetComponent<Text>();
    }

    // button onclick listener added in Start() and CreateCustomer() in CustomerSpawner.cs
    public void OpenClosePanel()
    {
        customer = GameObject.Find("Customer").GetComponent<Customer>();

        if (!panelActive)
        {
            // bring panel to top layer
            orderPanel.transform.SetAsLastSibling();

            orderPanel.SetActive(true);
            SetPanelText();
            panelActive = true;
        }
        else
        {
            orderPanel.SetActive(false);
            panelActive = false;
        }
        SoundManager.instance.PlaySingle(SoundManager.openSound);
    }

    // adding text to all fields
    private void SetPanelText()
    {
        customerName.text = "Name: " + customer.CustomerName;
        customerClass.text = "Class: " + customer.ClassType;
        orderType.text = "Order Type: " + customer.CustomerOrder.OrderType;
        potionName.text = "Potion: " + customer.CustomerOrder.OrderPotion.PotionName;
        orderPurpose.text = "Purpose: " + customer.CustomerOrder.OrderPurpose;
        price.text = "Price: " + customer.CustomerOrder.OrderPotion.price.ToString() + "g";
    }
}
