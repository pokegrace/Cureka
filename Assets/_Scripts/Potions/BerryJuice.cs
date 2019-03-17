using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BerryJuice : Potion
{
    public BerryJuice()
    {
        PotionName = "Berry Juice";
        potionType = "OTC";
        description = "A bottle of the juice from the land's most delectable berries. Used for various craft recipes.";

        price = 300;
    }
}
