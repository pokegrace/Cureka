using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RulesHandler : MonoBehaviour
{
    [SerializeField] private GameObject rulesPanel;
    [SerializeField] private Image image;
    [SerializeField] private Button closeButton;
    [SerializeField] private Button rightButton;
    [SerializeField] private Button leftButton;
    [SerializeField] private Text titleText;
    [SerializeField] private Text rulesText;

    private bool panelOpen;
    private int pageCounter;
    private string text0, text1, text2, text3, text4, text5, text6, text7;

    private void Start()
    {
        pageCounter = 0;
        text0 = "Click on customer's order form to view it in detail.";
        text1 = "If Order Type is OTC: give them the correct potion from OTC potion inventory.";
        text2 = "If Order Type is Prescription: ask them for their special form by clicking the Special Form button.";
        text3 = "If the customer does not have a special form, deny their order. If they do have a special form, click it to view in detail.";
        text4 = "If the customer's order purpose is Personal, they must have valid Prescription. The name, class, and potion order must all match the order form.";
        text5 = "If the customer's order purpose is Delivery, they must have Delivery Permit. The seal on the permit must be this valid one:";
        text6 = "If the customer's order purpise is Alchemy or Apothecary, they must have Alchemist's Permit. The seal on the permit must be this valid one:";
        text7 = "If the customer's order purpise is Wizardry, they must have Wizard's Permit.The seal on the permit must be this valid one:";

        rulesText.text = text0;
        image.sprite = Resources.Load<Sprite>("orderform");
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
        if (pageCounter >= 7)
            pageCounter = 7;
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
                image.sprite = Resources.Load<Sprite>("orderform");
                break;
            case 1:
                titleText.text = "OTC";
                rulesText.text = text1;
                image.sprite = Resources.Load<Sprite>("orderform");
                break;
            case 2:
                titleText.text = "Prescription";
                rulesText.text = text2;
                image.sprite = Resources.Load<Sprite>("specialform");
                break;
            case 3:
                titleText.text = "Prescription";
                rulesText.text = text3;
                image.sprite = Resources.Load<Sprite>("specialform");
                break;
            case 4:
                titleText.text = "Prescription";
                rulesText.text = text4;
                image.sprite = Resources.Load<Sprite>("specialform");
                break;
            case 5:
                titleText.text = "Delivery";
                rulesText.text = text5;
                image.sprite = Resources.Load<Sprite>("broom");
                break;
            case 6:
                titleText.text = "Alchemy/Apothecary";
                rulesText.text = text6;
                image.sprite = Resources.Load<Sprite>("alchemy");
                break;
            case 7:
                titleText.text = "Wizardry";
                rulesText.text = text7;
                image.sprite = Resources.Load<Sprite>("wizardry");
                break;
            default:
                break;
        }
    }
}
