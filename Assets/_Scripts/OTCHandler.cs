using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OTCHandler : MonoBehaviour
{
    [SerializeField] private GameObject otcPanel;

    private bool panelOpen = false;
    private Button closeButton;
    
    // Start is called before the first frame update
    void Start()
    {
        closeButton = otcPanel.transform.GetChild(0).GetComponent<Button>();
        closeButton.onClick.AddListener(() => OpenClosePanel());
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
}
