using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CustomerSpawner : MonoBehaviour
{
    [SerializeField] private GameObject customerClone;
    [SerializeField] private GameObject orderButtonClone;

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
            orderPanelHandler = GameObject.Find("EventSystem").GetComponent<OrderPanelHandler>();

            // finding button, childing it to the main canvas
            orderFormButton = Instantiate(orderButtonClone, GameObject.FindGameObjectWithTag("Canvas").transform).GetComponent<Button>();
            orderFormButton.transform.SetSiblingIndex(2);
            orderFormButton.transform.localPosition = new Vector3(110, -115, 0);

            // adding onClick listener to customer's order button
            orderFormButton.onClick.AddListener(() => orderPanelHandler.OpenClosePanel());

            // setting customer's fields
            customer.CustomerName = OrderAssigner.nameList[Random.Range(0, OrderAssigner.nameList.Count - 1)];
            customer.ClassType = OrderAssigner.classList[Random.Range(0, OrderAssigner.classList.Count - 1)];

            customer.CreateOrder();
            OrderAssigner.GiveSpecialForm(customer);

            customerSpawned = true;
        }
    }

    public IEnumerator DestroyCustomer(string state)
    {
        Animator animator = GameObject.Find("Customer").transform.Find("emote animator").GetComponent<Animator>();
        animator.SetBool(state, true);

        yield return new WaitForSeconds(1.5f);

        // destroy customer and their forms
        Destroy(c.gameObject);
        Destroy(orderFormButton.gameObject);
        if(c.GetComponent<Customer>().hasSpecialForm)
            Destroy(GameObject.Find("Special Form Button").gameObject);

        // close panel if it's open
        if (orderPanelHandler.panelActive)
            orderPanelHandler.OpenClosePanel();
        if (specialFormsHandler.panelOpen)
        {
            if (GameObject.Find("Prescription"))
                specialFormsHandler.OpenClosePanel(GameObject.Find("Prescription"));
            else if(GameObject.Find("Permit"))
                specialFormsHandler.OpenClosePanel(GameObject.Find("Permit"));
        }

        // reset denyCorrect to false
        player.denyCorrect = false;

        customerSpawned = false;
        StartCoroutine("Spawn");
    }
}
