using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Windmill : MonoBehaviour
{
    private bool triggerEntered;
    private bool firstEnter = false;
    private float charge;
    private bool isCharging = false;
    private Text overlayText;
    [TextArea(3,10)]
    public string overlayTextString;
    [Range(0.01f, 0.15f)] public float chargeRate;
    [Range(0.001f, 0.05f)] public float environmentRate;
    public GameObject chargeObject;
    public Image progressFill;
    public GameObject preview;
    public Placement placement;
    public HandleObjective handleObjective;
    public Canvas canvas;

    private void Start()
    {
        handleObjective = GameObject.Find("Canvas/Objective Panel").GetComponent<HandleObjective>();
        gameObject.name = "Windmill";
        preview = GameObject.Find("Previews/Windmill");
        placement = preview.GetComponent<Placement>();
        placement.FindPlaceableObject();
        placement.isPlacing = true;
        canvas.worldCamera = Camera.main;
    }

    private void Update()
    {
        if (handleObjective.objective[3].isActive)
        {
            handleObjective.CompleteObjective();
        }
        GenerateCharge();
        EnvironmentalEffect();
        if (triggerEntered)
        {
            progressFill.fillAmount = charge;
            if (Input.GetKeyDown(KeyCode.F))
            {
                AkSoundEngine.PostEvent("windmillOn", gameObject);
                HandleLife.charging = true;
                HandleLife.newHealth = HandleLife.currentHealth + charge;
                charge = 0;
                if (HandleLife.newHealth >= 1.0f)
                {
                    charge = HandleLife.newHealth - 1.0f;
                    HandleLife.newHealth = 1.0f;
                }
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
        if (!firstEnter)
        {
            overlayText = GameObject.Find("Canvas/PickupText").GetComponent<Text>();
            firstEnter = true;
        }
        overlayText.text = overlayTextString;
        chargeObject.SetActive(true);
        triggerEntered = true;
    }

    private void OnTriggerExit(Collider other)
    {
        chargeObject.SetActive(false);
        overlayText.text = "";
        triggerEntered = false;
        AkSoundEngine.PostEvent("windmillOff", gameObject);
    }

    private void GenerateCharge()
    {
        if (!isCharging)
        {
            if (charge < 1)
            {
                charge += Time.deltaTime * chargeRate;
            }
            else
            {
                charge = 1;
            }
        }
    }

    private void EnvironmentalEffect()
    {
        HandleEnvironment.newEnvironmentHealth =
            HandleEnvironment.newEnvironmentHealth - environmentRate * Time.deltaTime;
    }
}
