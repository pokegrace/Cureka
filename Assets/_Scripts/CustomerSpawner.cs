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

    private Player player;
    private OrderPanelHandler orderPanelHandler;
    private SpecialFormsHandler specialFormsHandler;

    private void Start()
    {
        StartCoroutine("Spawn");

        player = GameObject.Find("EventSystem").GetComponent<Player>();
        specialFormsHandler = GameObject.Find("EventSystem").GetComponent<SpecialFormsHandler>();
    }

    IEnumerator Spawn()
    {
        float randTime = Random.Range(1.0f, 6.0f);
        
        if(!customerSpawned)
        {
            yield return new WaitForSeconds(randTime);
            CreateCustomer();
        }
            
    }

    public void CreateCustomer()
    {
        // only create customer if there isn't one already
        if(c == null)
        {
            c = Instantiate(customerClone);
            c.name = "Customer";

            // finding all components from customer
            Customer customer = c.GetComponent<Customer>();
            orderPanelHandler = customer.GetComponent<OrderPanelHandler>();

            // finding button, childing it to the main canvas
            orderFormButton = customer.transform.GetChild(0).GetComponent<Button>();
            orderFormButton.transform.SetParent(GameObject.FindGameObjectWithTag("Canvas").transform);
            orderFormButton.transform.SetSiblingIndex(2);

            // adding onClick listener to customer's order button
            orderFormButton.onClick.AddListener(() => orderPanelHandler.OpenClosePanel());

            // setting customer's fields
            customer.CustomerName = customer.nameList[(int)Random.Range(0, customer.nameList.Count - 1)];
            customer.ClassType = customer.classList[(int)Random.Range(0, customer.classList.Count - 1)];

            customer.CreateOrder();

            // deciding if customer has special form or not
            if(customer.CustomerOrder.OrderType.Equals("Prescription"))
            {
                int r = Random.Range(0, 2);
                if (r == 0)
                    customer.hasSpecialForm = true;
                else
                    customer.hasSpecialForm = false;

                Debug.Log("has special form: " + customer.hasSpecialForm);
            }

            customerSpawned = true;
        }
    }

    public void DestroyCustomer()
    {
        // destroy customer and their forms
        Destroy(c.gameObject);
        Destroy(orderFormButton.gameObject);
        Destroy(GameObject.Find("button_specialform").gameObject);

        // close panel if it's open
        if (orderPanelHandler.panelActive)
            orderPanelHandler.OpenClosePanel();
        if (specialFormsHandler.prescPanelOpen)
            specialFormsHandler.OpenClosePanel();

        // reset denyCorrect to false
        player.denyCorrect = false;

        customerSpawned = false;
        StartCoroutine("Spawn");
    }
}
