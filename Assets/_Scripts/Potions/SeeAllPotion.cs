using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeeAllPotion : Potion
{
    public SeeAllPotion()
    {
        PotionName = "See All Potion";
        potionType = "Prescription";
        description = "Apply two drops into an eye to see a glimpse into the future.";

        price = 2500;
    }
}
