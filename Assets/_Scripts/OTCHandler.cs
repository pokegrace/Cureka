using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OTCHandler : MonoBehaviour
{
    [SerializeField] private GameObject otcPanel;
    [SerializeField] private Button healthPotion;
    [SerializeField] private Button gHealthPotion;

    private bool panelOpen = false;
    private Button closeButton;

    private Player player;
    private Customer customer;
    private CustomerSpawner customerSpawner;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("EventSystem").GetComponent<Player>();
        customerSpawner = GameObject.Find("Spawner").GetComponent<CustomerSpawner>();

        // setting onclick listeners
        closeButton = otcPanel.transform.GetChild(0).GetComponent<Button>();
        closeButton.onClick.AddListener(() => OpenClosePanel());

        healthPotion.onClick.AddListener(() => CheckPotion("Health Potion"));
        gHealthPotion.onClick.AddListener(() => CheckPotion("Greater Health Potion"));
    }

    public void OpenClosePanel()
    {
        if (!panelOpen)
        {
            otcPanel.SetActive(true);
            panelOpen = true;
        }
        else
        {
            otcPanel.SetActive(false);
            panelOpen = false;
        }
    }

    private void CheckPotion(string potionName)
    {
        // referencing customer
        customer = GameObject.Find("Customer").GetComponent<Customer>();

        // if player selects the potion that is on customer's order
        if (potionName.Equals(customer.CustomerOrder.OrderPotion.PotionName))
        {
            // add potion amount to player's gold amount and destroy customer
            player.goldAmount += customer.CustomerOrder.OrderPotion.price;
            customerSpawner.DestroyCustomer();

            OpenClosePanel();
        }
        else
        {
            Debug.Log("Wrong potion!");
        }
    }
}
