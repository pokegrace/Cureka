using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpecialFormsHandler : MonoBehaviour
{
    [SerializeField] private GameObject prescPanel;
    [SerializeField] private Button askPrescButton;

    public bool prescPanelOpen;
    public bool orderCorrect = false;

    private Customer customer;
    private Player player;
    private Button specialFormButton;

    private void Start()
    {
        player = GameObject.Find("EventSystem").GetComponent<Player>();
        askPrescButton.onClick.AddListener(() => AskPrescription());
    }

    private void AskPrescription()
    {
        customer = GameObject.Find("Customer").GetComponent<Customer>();

        // if the customer's order is a prescription and they have special form
        if (customer.CustomerOrder.OrderType.Equals("Prescription") && customer.hasSpecialForm)
        {
            // get customer's special order form button and set it as a child to canvas
            specialFormButton = customer.transform.GetChild(0).GetComponent<Button>();
            specialFormButton.transform.SetParent(GameObject.FindGameObjectWithTag("Canvas").transform);
            specialFormButton.transform.SetSiblingIndex(3);

            // adding onclick listener to the prescription order form
            specialFormButton.onClick.AddListener(() => DisplayPrescription(customer));
        }
        else if(customer.CustomerOrder.OrderType.Equals("Prescription") && customer.hasSpecialForm == false)
        {
            // player has no special order when they're supposed to
            player.denyCorrect = true;
        }
    }

    private void DisplayPrescription(Customer customer)
    {
        // deciding if the prescription will be correct or not
        int r = (int)Random.Range(0, 2);
        if (r == 0)
        {
            orderCorrect = true;
        } 
        else
        {
            orderCorrect = false;
            player.denyCorrect = true;
        }

        SetPanelText(prescPanel, orderCorrect);
        OpenClosePanel();
    }

    public void OpenClosePanel()
    {
        if (!prescPanelOpen)
        {
            // bring panel to top layer
            prescPanel.transform.SetAsLastSibling();

            prescPanel.SetActive(true);
            prescPanelOpen = true;
        }
        else
        {
            prescPanel.SetActive(false);
            prescPanelOpen = false;
        }
    }

    // sets the special order text to either correct or incorrect order
    // TODO: remove possibility of getting duplicate name if !orderCorrect
    private void SetPanelText(GameObject panel, bool orderCorrect)
    {
        foreach(Transform child in panel.transform)
        {
            if (child.gameObject.name.Equals("text_customername"))
            {
                if (orderCorrect)
                    child.gameObject.GetComponent<Text>().text = "Name: " + customer.CustomerName;
                else
                    child.gameObject.GetComponent<Text>().text = "Name: " + customer.nameList[(Random.Range(0, customer.nameList.Count - 1))];
            }
            else if (child.gameObject.name.Equals("text_class"))
            {
                panel.transform.Find("text_class").GetComponent<Text>().text = "Class: " + customer.ClassType;
            }
            else if (child.gameObject.name.Equals("text_potion"))
            {
                if (orderCorrect)
                    child.gameObject.GetComponent<Text>().text = "Potion: " + customer.CustomerOrder.OrderPotion.PotionName;
                else
                    child.gameObject.GetComponent<Text>().text = "Potion: " +
                        customer.CustomerOrder.PrescriptionPotions[Random.Range(0, customer.CustomerOrder.PrescriptionPotions.Length)].PotionName;
            }
            else if(child.gameObject.name.Equals("text_purpose"))
            {
                child.gameObject.GetComponent<Text>().text = "Purpose: " + customer.CustomerOrder.OrderPurpose;
            }
            else if(child.gameObject.name.Equals("text_price"))
            {
                panel.transform.Find("text_price").GetComponent<Text>().text = "Price: " + customer.CustomerOrder.OrderPotion.price;
            }
        }  
    }

    // returns a number within range, except for one number
    private int RandomExcept(int min, int max, int except)
    {
        int index;
        do
        {
            index = Random.Range(min, max);
        }
        while (index != except);

        return index;
    }
}
