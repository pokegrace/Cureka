using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Potion : MonoBehaviour
{
    private string potionName;
    public string PotionName
    {
        get { return potionName; }
        set { potionName = value; }
    }

    public int price;
    public string description;
    public string potionType;
}
