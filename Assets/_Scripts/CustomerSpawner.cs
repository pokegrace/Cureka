using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomerSpawner : MonoBehaviour
{
    [SerializeField] private GameObject customerClone;
    private bool customerSpawned = false;

    private string[] speciesList = new string[]
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
        float randTime = Random.Range(5.0f, 10.0f);

        yield return new WaitForSeconds(randTime);
        CreateCustomer();
    }

    private void CreateCustomer()
    {
        GameObject c = Instantiate(customerClone);
        Customer customer = c.GetComponent<Customer>();

        // setting customer's fields
        customer.CustomerName = nameList[(int)Random.Range(0, nameList.Length)];
        customer.Species = speciesList[(int)Random.Range(0, speciesList.Length)];

        Debug.Log("Name: " + customer.CustomerName);
        Debug.Log("Species: " + customer.Species);

        customer.CreateOrder();
        Debug.Log("Order: " + customer.CustomerOrder.OrderType);

        customerSpawned = true;
    }
}
