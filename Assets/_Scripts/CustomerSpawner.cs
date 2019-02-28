using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CustomerSpawner : MonoBehaviour
{
    [SerializeField] private GameObject customerClone;
    private bool customerSpawned = false;

    private string[] classList = new string[]
    {
        "Courier",
        "Lackey",
        "Adventurer",
        "Alchemist",
        "Sorcerer",
        "Herbalist",
        "Shaman",
        "Wizard"
    };
    private string[] nameList = new string[]
    {
        "Tim",
        "Bill",
        "Nelly",
        "Mina",
        "Eldritch Mystifier"
    };

    private void Start()
    {
        StartCoroutine("Spawn");
    }

    IEnumerator Spawn()
    {
        Debug.Log("Coroutine started");
        float randTime = Random.Range(1.0f, 6.0f);

        yield return new WaitForSeconds(randTime);
        CreateCustomer();
    }

    private void CreateCustomer()
    {
        GameObject c = Instantiate(customerClone);
        c.name = "Customer";

        // finding all components from customer
        Customer customer = c.GetComponent<Customer>();
        UIHandler uiHandler = customer.GetComponent<UIHandler>();

        // finding button, childing it to the main canvas
        Button orderFormButton = customer.transform.GetChild(0).GetChild(0).GetComponent<Button>();
        orderFormButton.transform.SetParent(GameObject.FindGameObjectWithTag("Canvas").transform);
        orderFormButton.transform.SetSiblingIndex(0);

        // adding onClick listener to customer's order button
        orderFormButton.onClick.AddListener(() => uiHandler.SetPanelActive());

        // setting customer's fields
        customer.CustomerName = nameList[(int)Random.Range(0, nameList.Length)];
        customer.ClassType = classList[(int)Random.Range(0, classList.Length)];

        customer.CreateOrder();

        customerSpawned = true;
    }
}
