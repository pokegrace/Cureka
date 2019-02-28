using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GreaterHealthPotion : Potion
{
    public GreaterHealthPotion()
    {
        this.PotionName = "Greater Health Potion";
        potionType = "OTC";
        description = "A great healing potion created by the Great Wizard himself. Heals 25 HP.";

        price = 1200;
    }
}
