using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class HandleInventory : MonoBehaviour
{
    public static int scrap = 100;
    public static int wood = 100;
    public static int electronics = 100;
    public CraftingRecipe craftingRecipe;
    
    private HandleObjective handleObjective;

    static Text scrapText;
    static Text woodText;
    static Text electronicsText;

    private void Start()
    {
        scrapText = GameObject.Find("ScrapText").GetComponent<Text>();
        woodText = GameObject.Find("WoodText").GetComponent<Text>();
        electronicsText = GameObject.Find("ElectronicsText").GetComponent<Text>();
        handleObjective = GameObject.Find("Objective Panel").GetComponent<HandleObjective>();
        UpdateInventory();
    }

    // Update is called once per frame
    void Update()
    {
        if (scrap >= craftingRecipe.scrapCost && wood >= craftingRecipe.woodCost &&
            electronics >= craftingRecipe.electronicsCost && handleObjective.objective[1].isActive)
        {
            handleObjective.CompleteObjective();
        }
    }

    public void CheckCosts()
    {
        
    }

    public static void UpdateInventory()
    {
        scrapText.text = "Scrap: " + scrap;
        woodText.text = "Wood: " + wood;
        electronicsText.text = "Electronic Parts: " + electronics;
    }
}
