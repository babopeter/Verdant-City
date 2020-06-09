using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Generator : MonoBehaviour
{
    public GameObject overlayText;
    private Text overlayTextComponent;
    [TextArea(3,10)]
    public string overlayTextString;
    public float environmentalEffect;
    public GameObject preview;
    public Placement placement;
    private bool firstEnter = false;
    public HandleObjective handleObjective;

    public int woodCost;

    private bool triggerEntered;
    
    // Start is called before the first frame update
    void Start()
    {
        handleObjective = GameObject.Find("Canvas/Objective Panel").GetComponent<HandleObjective>();
        //AkSoundEngine.PostEvent("craftItem", gameObject);
        gameObject.name = "Generator";
        preview = GameObject.Find("Previews/Generator");
        placement = preview.GetComponent<Placement>();
        placement.FindPlaceableObject();
        placement.isPlacing = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (handleObjective.objective[2].isActive)
        {
            handleObjective.CompleteObjective();
        }
        if (triggerEntered)
        {
            if (Input.GetKeyDown(KeyCode.F) && HandleInventory.wood >= woodCost)
            {
                HandleLife.charging = true;
                HandleLife.newHealth = 1.0f;
                HandleInventory.wood -= woodCost;
                HandleEnvironment.newEnvironmentHealth += environmentalEffect;
                AkSoundEngine.PostEvent("generatorOn", gameObject);
            }

            if (Input.GetMouseButtonDown(1))
            {
                transform.position = new Vector3(0.0f, -100.0f, 0.0f);
                placement.isPlacing = true;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        triggerEntered = true;
        
        if (!firstEnter)
        {
            overlayText = GameObject.Find("Canvas/PickupText");
            overlayTextComponent = overlayText.GetComponent<Text>();
            firstEnter = true;
        }
        overlayTextComponent.text = overlayTextString;
    }

    private void OnTriggerExit(Collider other)
    {
        triggerEntered = false;
        overlayTextComponent.text = "";
        AkSoundEngine.PostEvent("generatorOff", gameObject);
    }
}
