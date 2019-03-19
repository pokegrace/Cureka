using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToadToxin : Potion
{
    public ToadToxin()
    {
        PotionName = "Toad Toxin";
        potionType = "Prescription";
        description = "A topical ointment used to treat toad bumps. Use carefully!";

        price = 2000;
    }
}
