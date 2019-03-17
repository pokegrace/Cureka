using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrderAssigner : MonoBehaviour
{
    // lists of names/classes
    public static List<string> classList = new List<string>(new string[]
    {
        "Courier",
        "Lackey",
        "Adventurer",
        "Alchemist",
        "Sorcerer",
        "Herbalist",
        "Shaman",
        "Wizard"
    });

    public static List<string> nameList = new List<string>(new string[]
    {
        "Helena",
        "Cordon",
        "Seilia",
        "Grendil",
        "Eldris",
        "Mervin",
        "Ariel"
    });

    // arrays of potions
    public static Potion[] OTCPotions = new Potion[]
    {
        new HealthPotion(),
        new GreaterHealthPotion()
    };
    public static Potion[] PrescriptionPotions = new Potion[]
    {
        new PolymorphicPotion(),
        new LemonWater()
    };
}
