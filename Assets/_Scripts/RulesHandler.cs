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
    [SerializeField] private Text rulesText;

    private bool panelOpen;
    private int pageCounter;

    private void Start()
    {
        closeButton.onClick.AddListener(() => OpenClosePanel());
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
}
