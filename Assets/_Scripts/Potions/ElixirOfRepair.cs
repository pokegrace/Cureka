using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElixirOfRepair : Potion
{
    public ElixirOfRepair()
    {
        PotionName = "Elixir Of Repair";
        potionType = "OTC";
        description = "A drop of this on any inanimate object will restore it to its newest version.";

        price = 1000;
    }
}
