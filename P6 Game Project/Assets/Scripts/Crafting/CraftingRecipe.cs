using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class CraftingRecipe : ScriptableObject
{
    //public List<Ingredients> Materials;
    public bool crafted;
    public Vector3 instPosition;
    public GameObject item;
    public int woodCost;
    public int scrapCost;
    public int electronicsCost;

    public void Craft()
    {
        if (!crafted)
        {
            if (HandleInventory.wood >= woodCost && HandleInventory.scrap >= scrapCost &&
                HandleInventory.electronics >= electronicsCost)
            {
                HandleInventory.wood -= woodCost;
                HandleInventory.scrap -= scrapCost;
                HandleInventory.electronics -= electronicsCost;
                HandleInventory.UpdateInventory();
                Instantiate(item, instPosition, Quaternion.identity);
                crafted = true;
            }
        }
    }
}
