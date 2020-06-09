using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CraftingTable : MonoBehaviour
{
    [TextArea(3,10)]
    public string overlayString;
    private HandleObjective handleObjective;
    public Placement placement;
    public GameObject waypointMarker;

    private Text overlayText;

    private bool triggerEntered = false;
    // Start is called before the first frame update
    void Start()
    {
        handleObjective = GameObject.Find("Objective Panel").GetComponent<HandleObjective>();
        overlayText = GameObject.Find("PickupText").GetComponent<Text>();
    }

    private void Update()
    {
        if (!placement.isPlacing)
        {
            waypointMarker.SetActive(true);
        }
        if (triggerEntered)
        {
            if (Input.GetMouseButtonDown(1))
            {
                transform.position = new Vector3(0.0f, -100.0f, 0.0f);
                waypointMarker.SetActive(false);
                placement.isPlacing = true;
                AkSoundEngine.PostEvent("moveItem", gameObject);
            }
            if (handleObjective.objective[0].isActive)
            {
                handleObjective.CompleteObjective();
            }
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            overlayText.text = overlayString;
            triggerEntered = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            overlayText.text = "";
            triggerEntered = false;
        }
    }
}
