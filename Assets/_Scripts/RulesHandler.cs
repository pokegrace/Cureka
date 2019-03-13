using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RulesHandler : MonoBehaviour
{
    [SerializeField] private GameObject rulesPanel;
    [SerializeField] private Button closeButton;
    [SerializeField] private Button rightButton;
    [SerializeField] private Button leftButton;
    [SerializeField] private Text titleText;
    [SerializeField] private Text rulesText;

    private bool panelOpen;
    private int pageCounter;
    private string text0, text1, text2, text3, text4, text5;

    private void Start()
    {
        pageCounter = 0;
        text0 = "Click on a customer to bring up their order form, and check the potion they require." +
                "\n\nTake extra care not to give them the wrong potion, or we will lose out on gold!";
        text1 = "An Over-the-Counter (OTC) order is common, and the customer is not required to show you paperwork to purchase one." +
                "\n\nSimply select the OTC category and select the correct potion to give to the customer.";
        text2 = "A customer of any class can come in to ask for a prescription potion for personal use." +
                "\n\nIn order to purchase a prescription potion for personal use, the customer must have a valid prescription.";
        text3 = "DENY the customer if the information on the order form does not match the prescription." +
                "\n\n DENY the customer if he/she fails to show a form at all.";


        rulesText.text = text0;
        closeButton.onClick.AddListener(() => OpenClosePanel());
        rightButton.onClick.AddListener(() => ClickRightArrow());
        leftButton.onClick.AddListener(() => ClickLeftArrow());
    }

    public void OpenClosePanel()
    {
        if (!panelOpen)
        {
            // bring panel to top layer
            rulesPanel.transform.SetAsLastSibling();

            rulesPanel.SetActive(true);
            panelOpen = true;
        }
        else
        {
            rulesPanel.SetActive(false);
            panelOpen = false;
        }
    }

    private void ClickRightArrow()
    {
        if (pageCounter >= 5)
            pageCounter = 5;
        else
            ++pageCounter;

        SetPanelText(pageCounter);
    }

    private void ClickLeftArrow()
    {
        if (pageCounter <= 0)
            pageCounter = 0;
        else
            --pageCounter;

        SetPanelText(pageCounter);
    }

    private void SetPanelText(int pageNumber)
    {
        switch(pageNumber)
        {
            case 0:
                titleText.text = "Rules";
                rulesText.text = text0;
                break;
            case 1:
                titleText.text = "OTC";
                rulesText.text = text1;
                break;
            case 2:
                titleText.text = "Prescription";
                rulesText.text = text2;
                break;
            case 3:
                titleText.text = "Prescription";
                rulesText.text = text3;
                break;
            case 4:
                titleText.text = "Alchemy";
                rulesText.text = text4;
                break;
            case 5:
                titleText.text = "Wizardry";
                rulesText.text = text5;
                break;
            default:
                break;
        }
    }
}
