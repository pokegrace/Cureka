using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPotion : Potion
{
    public HealthPotion()
    {
        PotionName = "Health Potion";
        potionType = "OTC";
        description = "A small healing potion created from the juices of the fire flower. Heals 4 - 10 HP.";

        price = 400;
    }
}
