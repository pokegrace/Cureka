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
    }

    public void DenyCustomer()
    {
        if (denyCorrect)
        {
            customerSpawner.PlayAnimation("Angry");
            SoundManager.instance.PlaySingle(SoundManager.angrySound);
        }
        // if player wasn't supposed to deny customer but did
        else
        {
            // increment mistake counter
            ++mistakeAmount;
            // play emote and destroy customer
            customerSpawner.PlayAnimation("Wrong");
            SoundManager.instance.PlaySingle(SoundManager.incorrectSound);
        }
    }
}
