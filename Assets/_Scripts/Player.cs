using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    [SerializeField] private Text goldValue;
    public int goldAmount;

    private void Update()
    {
        goldValue.text = goldAmount.ToString();
    }
}
