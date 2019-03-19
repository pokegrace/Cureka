using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PotionHandler : MonoBehaviour
{
    [SerializeField] private GameObject otcPanel;
    [SerializeField] private GameObject prescPanel;

    private Button[] otcPotions;
    private Button[] prescPotions;

    private bool otcOpen = false;
    private bool prescOpen = false;
    private Button closeOTC;
    private Button closePresc;

    private Player player;
    private Customer customer;
    private CustomerSpawner customerSpawner;
    private SpecialFormsHandler specialFormsHandler;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("EventSystem").GetComponent<Player>();
        customerSpawner = GameObject.Find("Spawner").GetComponent<CustomerSpawner>();
        specialFormsHandler = GameObject.Find("EventSystem").GetComponent<SpecialFormsHandler>();

        // setting onclick listeners to close panels
        closeOTC = otcPanel.transform.GetChild(0).GetComponent<Button>();
        closeOTC.onClick.AddListener(() => OpenCloseOTC());
        closePresc = prescPanel.transform.GetChild(0).GetComponent<Button>();
        closePresc.onClick.AddListener(() => OpenClosePresc());

        otcPotions = otcPanel.GetComponentsInChildren<Button>();
        prescPotions = prescPanel.GetComponentsInChildren<Button>();

        // assigning onclick listeners to each potion button
        foreach(Button b in otcPotions)
        {
            b.onClick.AddListener(() => CheckOTCPotion(b.name));
        }
        foreach(Button b in prescPotions)
        {
            b.onClick.AddListener(() => CheckPrescPotion(b.name));
        }
    }

    public void OpenCloseOTC()
    {
        if (!otcOpen)
        {
            otcPanel.SetActive(true);
            otcOpen = true;
        }
        else
        {
            otcPanel.SetActive(false);
            otcOpen = false;
        }
    }

    public void OpenClosePresc()
    {
        if (!prescOpen)
        {
            prescPanel.SetActive(true);
            prescOpen = true;
        }
        else
        {
            prescPanel.SetActive(false);
            prescOpen = false;
        }
    }

    private void CheckOTCPotion(string potionName)
    {
        // referencing customer
        customer = GameObject.Find("Customer").GetComponent<Customer>();

        // if player selects the potion that is on customer's order
        if (potionName.Equals(customer.CustomerOrder.OrderPotion.PotionName))
        {
            // add potion amount to player's gold amount and destroy customer
            player.GoldAmount += customer.CustomerOrder.OrderPotion.price;
            StartCoroutine(customerSpawner.DestroyCustomer("Wrong"));

            OpenCloseOTC();
        }
        // if player makes a mistake, increment counter and destroy customer
        else
        {
            player.MistakeAmount += 1;
            OpenCloseOTC();
            StartCoroutine(customerSpawner.DestroyCustomer("Wrong"));
        }
    }

    private void CheckPrescPotion(string potionName)
    {
        customer = GameObject.Find("Customer").GetComponent<Customer>();

        // if player selects the potion that is on customer's order
        if (potionName.Equals(customer.CustomerOrder.OrderPotion.PotionName))
        {
            // if customer has no special form but player gave potion anyway
            if(customer.hasSpecialForm == false)
            {
                ++player.MistakeAmount;
            }
            // if special form was incorrect but player gave potion anyway
            else if(customer.hasSpecialForm && specialFormsHandler.orderCorrect == false)
            {
                ++player.MistakeAmount;
            }
            else
            {
                // add potion amount to player's gold amount and destroy customer
                player.GoldAmount += customer.CustomerOrder.OrderPotion.price;
            }
            OpenClosePresc();
            StartCoroutine(customerSpawner.DestroyCustomer("Wrong"));
        }
        else
        {
            player.MistakeAmount += 1;
            OpenClosePresc();
            StartCoroutine(customerSpawner.DestroyCustomer("Wrong"));
        }
    }
}
