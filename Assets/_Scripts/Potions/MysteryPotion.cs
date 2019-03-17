using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MysteryPotion : Potion
{
    public MysteryPotion()
    {
        PotionName = "Mystery Potion";
        potionType = "Prescription";
        description = "A mysterious, goo-like substance... Leave it to the experts to figure this one out.";

        price = 3000;
    }
}