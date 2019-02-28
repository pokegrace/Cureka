using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPotion : Potion
{
    public HealthPotion()
    {
        this.PotionName = "Health Potion";
        potionType = "OTC";
        description = "A small healing potion created by the Great Wizard himself. Heals 4 - 10 HP.";

        price = 400;
    }
}
