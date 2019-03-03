using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PrescHandler : MonoBehaviour
{
    [SerializeField] private GameObject prescPanel;

    private bool panelOpen = false;
    private Button closeButton;

    // Start is called before the first frame update
    void Start()
    {
        closeButton = prescPanel.transform.GetChild(0).GetComponent<Button>();
        closeButton.onClick.AddListener(() => OpenClosePanel());
    }

    public void OpenClosePanel()
    {
        if (!panelOpen)
        {
            prescPanel.SetActive(true);
            panelOpen = true;
        }
        else
        {
            prescPanel.SetActive(false);
            panelOpen = false;
        }
    }
}
