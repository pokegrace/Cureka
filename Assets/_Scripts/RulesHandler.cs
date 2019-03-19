using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RulesHandler : MonoBehaviour
{
    [SerializeField] private GameObject rulesPanel;
    [SerializeField] private GameObject alchemyImage;
    [SerializeField] private GameObject bigShelfImage;
    [SerializeField] private GameObject broomImage;
    [SerializeField] private GameObject denyImage;
    [SerializeField] private GameObject orderFormImage;
    [SerializeField] private GameObject shelfImage;
    [SerializeField] private GameObject specialFormImage;
    [SerializeField] private GameObject wizardryImage;

    [SerializeField] private Button closeButton;
    [SerializeField] private Button rightButton;
    [SerializeField] private Button leftButton;
    [SerializeField] private Text titleText;
    [SerializeField] private Text rulesText;

    private bool panelOpen;
    private int pageCounter;
    private readonly int maxPages = 9;
    private string text0, text1, text2, text3, text4, text5, text6, text7, text8;
    private GameObject image;

    private void Start()
    {
        pageCounter = 0;
        text0 = "Click on customer's order form to view it in detail.";
        text1 = "If Order Type is OTC: give them the correct potion by clicking on the OTC potion shelf.";
        text2 = "Prescription orders can be found by clicking the Prescription potion shelf.";
        text3 = "If Order Type is Prescription: ask them for their special form by clicking the Special Form button.";
        text4 = "If the customer does not have a special form, or their information does not match up, deny their order.";
        text5 = "If the customer's order purpose is Personal, they must have valid Prescription. The name, class, and potion order must all match the order form.";
        text6 = "If the customer's order purpose is Delivery, they must have Delivery Permit. The seal on the permit must be this valid one:";
        text7 = "If the customer's order purpise is Alchemy or Apothecary, they must have Alchemist's Permit. The seal on the permit must be this valid one:";
        text8 = "If the customer's order purpise is Wizardry, they must have Wizard's Permit.The seal on the permit must be this valid one:";

        rulesText.text = text0;
        image = Instantiate(orderFormImage, rulesPanel.transform);
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
        if (pageCounter >= maxPages)
            pageCounter = maxPages;
        else
            ++pageCounter;

        Destroy(image);

        SetPanelText(pageCounter);
    }

    private void ClickLeftArrow()
    {
        if (pageCounter <= 0)
            pageCounter = 0;
        else
            --pageCounter;

        Destroy(image);

        SetPanelText(pageCounter);
    }

    private void SetPanelText(int pageNumber)
    {
        switch(pageNumber)
        {
            case 0:
                titleText.text = "Rules";
                rulesText.text = text0;
                image = Instantiate(orderFormImage, rulesPanel.transform);
                break;
            case 1:
                titleText.text = "OTC";
                rulesText.text = text1;
                image = Instantiate(shelfImage, rulesPanel.transform);
                break;
            case 2:
                titleText.text = "Prescription";
                rulesText.text = text2;
                image = Instantiate(bigShelfImage, rulesPanel.transform);
                break;
            case 3:
                titleText.text = "Prescription";
                rulesText.text = text3;
                image = Instantiate(specialFormImage, rulesPanel.transform);
                break;
            case 4:
                titleText.text = "DENY";
                rulesText.text = text4;
                image = Instantiate(denyImage, rulesPanel.transform);
                break;
            case 5:
                titleText.text = "Prescription";
                rulesText.text = text5;
                image = Instantiate(specialFormImage, rulesPanel.transform);
                break;
            case 6:
                titleText.text = "Delivery";
                rulesText.text = text6;
                image = Instantiate(broomImage, rulesPanel.transform);
                break;
            case 7:
                titleText.text = "Alchemy/Apothecary";
                rulesText.text = text7;
                image = Instantiate(alchemyImage, rulesPanel.transform);
                break;
            case 8:
                titleText.text = "Wizardry";
                rulesText.text = text8;
                image = Instantiate(wizardryImage, rulesPanel.transform);
                break;
            default:
                break;
        }
    }
}
