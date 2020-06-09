using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public List<CraftingRecipe> craftableItem = new List<CraftingRecipe>(); 
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    private void OnApplicationQuit()
    {
        for (int i = 0; i < craftableItem.Count; i++)
        {
            craftableItem[i].crafted = false;
        }
        
    }

    private void OnDestroy()
    {
        for (int i = 0; i < craftableItem.Count; i++)
        {
            craftableItem[i].crafted = false;
        }
    }
}
