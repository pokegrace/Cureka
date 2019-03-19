using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeBalm : Potion
{
    public SnakeBalm()
    {
        PotionName = "Snake Balm";
        potionType = "OTC";
        description = "A salve that closes any wound. All adventurers should carry one on them.";

        price = 600;
    }
}
