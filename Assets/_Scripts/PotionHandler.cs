using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PotionHandler : MonoBehaviour
{
    [SerializeField] private GameObject otcPanel;
    [SerializeField] private GameObject prescPanel;

    [SerializeField] private Button healthPotion;
    [SerializeField] private Button gHealthPotion;
    [SerializeField] private Button polymorphicPotion;
    [SerializeField] private Button lemonWater;

    private bool otcOpen = false;
    private bool prescOpen = false;
    private Button closeOTC;
    private Button closePresc;

    private Player player;
    private Customer customer;
    private CustomerSpawner customerSpawner;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("EventSystem").GetComponent<Player>();
        customerSpawner = GameObject.Find("Spawner").GetComponent<CustomerSpawner>();

        // setting onclick listeners to close panels
        closeOTC = otcPanel.transform.GetChild(0).GetComponent<Button>();
        closeOTC.onClick.AddListener(() => OpenCloseOTC());
        closePresc = prescPanel.transform.GetChild(0).GetComponent<Button>();
        closePresc.onClick.AddListener(() => OpenClosePresc());

        // otc potions
        healthPotion.onClick.AddListener(() => CheckOTCPotion("Health Potion"));
        gHealthPotion.onClick.AddListener(() => CheckOTCPotion("Greater Health Potion"));

        // presc potions
        polymorphicPotion.onClick.AddListener(() => CheckPrescPotion("Polymorphic Potion"));
        lemonWater.onClick.AddListener(() => CheckPrescPotion("Lemon Water"));
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
            player.goldAmount += customer.CustomerOrder.OrderPotion.price;
            customerSpawner.DestroyCustomer();

            OpenCloseOTC();
        }
        // if player makes a mistake, increment counter and destroy customer
        else
        {
            player.mistakeAmount += 1;
            OpenCloseOTC();
            customerSpawner.DestroyCustomer();
        }
    }

    private void CheckPrescPotion(string potionName)
    {
        customer = GameObject.Find("Customer").GetComponent<Customer>();

        // if player selects the potion that is on customer's order
        if (potionName.Equals(customer.CustomerOrder.OrderPotion.PotionName))
        {
            // add potion amount to player's gold amount and destroy customer
            player.goldAmount += customer.CustomerOrder.OrderPotion.price;
            customerSpawner.DestroyCustomer();

            OpenClosePresc();
        }
        else
        {
            player.mistakeAmount += 1;
            OpenClosePresc();
            customerSpawner.DestroyCustomer();
        }
    }
}
