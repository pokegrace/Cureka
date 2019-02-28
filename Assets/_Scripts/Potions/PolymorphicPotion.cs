using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PolymorphicPotion : Potion
{
    public PolymorphicPotion()
    {
        this.PotionName = "Polymorphic Potion";
        potionType = "Prescription";
        description = "A sensitive potion that will polymorph any organism that breathes its scent in!";

        price = 1000;
    }
}