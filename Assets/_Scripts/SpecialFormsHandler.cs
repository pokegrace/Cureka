using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpecialFormsHandler : MonoBehaviour
{
    [SerializeField] private GameObject prescPanel;
    [SerializeField] private GameObject permitPanel;
    [SerializeField] private Button askPrescButton;

    public bool panelOpen;
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
            if(customer.transform.childCount > 0)
            {
                specialFormButton = customer.transform.GetChild(0).GetComponent<Button>();
                specialFormButton.transform.SetParent(GameObject.FindGameObjectWithTag("Canvas").transform);
                specialFormButton.transform.SetSiblingIndex(3);
            }

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
            Debug.Log("order correct: " + orderCorrect);

            // adding onclick listeners to special form icon
            if (customer.CustomerOrder.OrderPurpose.Equals("Personal"))
                specialFormButton.onClick.AddListener(() => DisplayPrescription());
            else if(customer.CustomerOrder.OrderPurpose.Equals("Delivery"))
                specialFormButton.onClick.AddListener(() => DisplayPermit());
            else if (customer.CustomerOrder.OrderPurpose.Equals("Alchemy") || customer.CustomerOrder.OrderPurpose.Equals("Apothecary"))
                specialFormButton.onClick.AddListener(() => DisplayPermit());
            else if (customer.CustomerOrder.OrderPurpose.Equals("Wizardry"))
                specialFormButton.onClick.AddListener(() => DisplayPermit());
        }
        else if(customer.CustomerOrder.OrderType.Equals("Prescription") && customer.hasSpecialForm == false)
        {
            // player has no special order when they're supposed to
            player.denyCorrect = true;
        }
    }

    private void DisplayPrescription()
    {
        SetPanelText(prescPanel);
        OpenClosePanel(prescPanel);
    }

    private void DisplayPermit()
    {
        SetPanelText(permitPanel);
        OpenClosePanel(permitPanel);
    }

    public void OpenClosePanel(GameObject panel)
    {
        if (!panelOpen)
        {
            // bring panel to top layer
            panel.transform.SetAsLastSibling();

            panel.SetActive(true);
            panelOpen = true;
        }
        else
        {
            panel.SetActive(false);
            panelOpen = false;
        }
    }

    // sets the special order text to either correct or incorrect order
    // TODO: remove possibility of getting duplicate name if !orderCorrect
    private void SetPanelText(GameObject panel)
    {
        foreach(Transform child in panel.transform)
        {
            if(child.gameObject.name.Equals("text_title"))
            {
                if(customer.CustomerOrder.OrderPurpose.Equals("Delivery"))
                {
                    child.gameObject.GetComponent<Text>().text = "Delivery Permit";
                }
                else if(customer.CustomerOrder.OrderPurpose.Equals("Alchemy") || customer.CustomerOrder.OrderPurpose.Equals("Apothecary"))
                {
                    child.gameObject.GetComponent<Text>().text = "Alchemist's Permit";
                }
                else if (customer.CustomerOrder.OrderPurpose.Equals("Wizardry"))
                {
                    child.gameObject.GetComponent<Text>().text = "Wizard's Permit";
                }
            }
            else if (child.gameObject.name.Equals("text_customername"))
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
            else if (child.gameObject.name.Equals("text_purpose"))
            {
                child.gameObject.GetComponent<Text>().text = "Purpose: " + customer.CustomerOrder.OrderPurpose;
            }
            else if (child.gameObject.name.Equals("text_price"))
            {
                panel.transform.Find("text_price").GetComponent<Text>().text = "Price: " + customer.CustomerOrder.OrderPotion.price;
            }
            else if(child.gameObject.name.Equals("image_seal"))
            {
                if(customer.CustomerOrder.OrderPurpose.Equals("Delivery"))
                {
                    if (orderCorrect)
                        child.gameObject.GetComponent<Image>().sprite = Resources.Load<Sprite>("broom");
                    else
                        child.gameObject.GetComponent<Image>().sprite = Resources.Load<Sprite>("broomIncorrect");
                }
                else if (customer.CustomerOrder.OrderPurpose.Equals("Alchemy") || customer.CustomerOrder.OrderPurpose.Equals("Apothecary"))
                {
                    if (orderCorrect)
                        child.gameObject.GetComponent<Image>().sprite = Resources.Load<Sprite>("alchemy");
                    else
                        child.gameObject.GetComponent<Image>().sprite = Resources.Load<Sprite>("alchemyIncorrect");
                }
                else if (customer.CustomerOrder.OrderPurpose.Equals("Wizardry"))
                {
                    if (orderCorrect)
                        child.gameObject.GetComponent<Image>().sprite = Resources.Load<Sprite>("wizardry");
                    else
                        child.gameObject.GetComponent<Image>().sprite = Resources.Load<Sprite>("wizardryIncorrect");
                }
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
