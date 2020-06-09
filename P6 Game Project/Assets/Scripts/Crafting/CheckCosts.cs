using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class CheckCosts : MonoBehaviour
{
    public float distanceToCraftingTable;
    public Transform player;
    public Transform craftingTable;
    public CraftingRecipe craftAbleItem;

    public Button craftButton;
    
    public Text scrapText;
    public Text woodText;
    public Text electronicsText;
    // Start is called before the first frame update
    void Start()
    {
        scrapText.text = scrapText.text + " " + craftAbleItem.scrapCost;
        woodText.text = woodText.text + " " + craftAbleItem.woodCost;
        electronicsText.text = electronicsText.text + " " + craftAbleItem.electronicsCost;
    }

    private void Update()
    {
        if (!craftAbleItem.crafted)
        {
            if (HandleInventory.wood >= craftAbleItem.woodCost && HandleInventory.scrap >= craftAbleItem.scrapCost &&
                HandleInventory.electronics >= craftAbleItem.electronicsCost)
            {
                if (Vector3.Distance(player.position, craftingTable.position) < distanceToCraftingTable)
                {
                    craftButton.interactable = true;
                }
                else
                {
                    craftButton.interactable = false;
                }
            } 
            else
            {
                craftButton.interactable = false;
            }
        }
        else
        {
            craftButton.interactable = false;
        }
    }

    public void UpdateTooltip()
    {
        if (!craftAbleItem.crafted)
        {
            if (Vector3.Distance(player.position, craftingTable.position) < distanceToCraftingTable)
            {
                if (HandleInventory.wood < craftAbleItem.woodCost || HandleInventory.scrap < craftAbleItem.scrapCost ||
                    HandleInventory.electronics < craftAbleItem.electronicsCost)
                {
                    Tooltip.ShowTooltip_Static("You are missing ingredients");
                }
                else
                {
                    Tooltip.HideTooltip_Static();
                }
            }
            else
            {
                Tooltip.ShowTooltip_Static("You need to be closer \n to the crafting table");
            }
        }
        else
        {
            Tooltip.ShowTooltip_Static("Item has already been crafted");
        }
    }
}