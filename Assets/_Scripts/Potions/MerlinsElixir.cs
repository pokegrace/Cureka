using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MerlinsElixir : Potion
{
    public MerlinsElixir()
    {
        PotionName = "Merlins Elixir";
        potionType = "Prescription";
        description = "An elixir that was crafted by the Great Merlin himself. Used as an ingredient for powerful spells.";

        price = 3500;
    }
}