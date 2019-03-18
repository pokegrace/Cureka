using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    [SerializeField] private Text goldValue;
    [SerializeField] private Text mistakeValue;

    private int goldAmount;
    private int mistakeAmount;
    private CustomerSpawner customerSpawner;

    public bool denyCorrect = false;
    
    // getters and setters
    public int GoldAmount
    {
        get { return goldAmount; }
        set { goldAmount = value; }
    }
    public int MistakeAmount
    {
        get { return mistakeAmount; }
        set { mistakeAmount = value; }
    }

    private void Start()
    {
        customerSpawner = GameObject.Find("Spawner").GetComponent<CustomerSpawner>();
    }

    private void Update()
    {
        goldValue.text = goldAmount.ToString();
        mistakeValue.text = mistakeAmount.ToString();

        if (mistakeAmount >= 3)
            SceneManager.LoadScene("GameOverScene");
    }

    public void DenyCustomer()
    {
        if (denyCorrect)
        {
            StartCoroutine(customerSpawner.DestroyCustomer("Wrong"));
        }
        // if player wasn't supposed to deny customer but did
        else
        {
            // increment mistake counter
            ++mistakeAmount;
            // play emote and destroy customer
            StartCoroutine(customerSpawner.DestroyCustomer("Wrong"));
        }
    }
}
