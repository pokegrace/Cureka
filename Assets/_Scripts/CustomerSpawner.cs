using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CustomerSpawner : MonoBehaviour
{
    [SerializeField] private GameObject customerClone;
    private bool customerSpawned = false;
    private GameObject c;
    private Button orderFormButton;

    private void Start()
    {
        //StartCoroutine("Spawn");
    }

    /*
    IEnumerator Spawn()
    {
        Debug.Log("Coroutine started");
        float randTime = Random.Range(1.0f, 6.0f);

        yield return new WaitForSeconds(randTime);
        CreateCustomer();
    }*/

    public void CreateCustomer()
    {
        c = Instantiate(customerClone);
        c.name = "Customer";

        // finding all components from customer
        Customer customer = c.GetComponent<Customer>();
        UIHandler uiHandler = customer.GetComponent<UIHandler>();

        // finding button, childing it to the main canvas
        orderFormButton = customer.transform.GetChild(0).GetChild(0).GetComponent<Button>();
        orderFormButton.transform.SetParent(GameObject.FindGameObjectWithTag("Canvas").transform);
        orderFormButton.transform.SetSiblingIndex(0);

        // adding onClick listener to customer's order button
        orderFormButton.onClick.AddListener(() => uiHandler.SetPanelActive());

        // setting customer's fields
        customer.CustomerName = customer.nameList[(int)Random.Range(0, customer.nameList.Length)];
        customer.ClassType = customer.classList[(int)Random.Range(0, customer.classList.Length)];

        customer.CreateOrder();

        customerSpawned = true;
    }

    public void DestroyCustomer()
    {
        Destroy(c.gameObject);
        Destroy(orderFormButton.gameObject);
    }
}
