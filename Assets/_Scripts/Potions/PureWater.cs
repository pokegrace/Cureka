using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PureWater : Potion
{
    public PureWater()
    {
        PotionName = "Pure Water";
        potionType = "OTC";
        description = "Water from the Healing Springs of the North. It's just a refreshingly good vial of water.";

        price = 200;
    }
}
