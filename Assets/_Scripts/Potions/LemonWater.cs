using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LemonWater : Potion
{
    public LemonWater()
    {
        this.PotionName = "Lemon Water";
        potionType = "Prescription";
        description = "A tangy, yellow substance... no one knows what it does, so it's best to leave the experimenting up to the experts.";

        price = 800;
    }
}