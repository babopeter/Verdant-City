//////////////////////////////////////////////////////////
///Source: https://www.youtube.com/watch?v=qXH3kO6V5Pg ///
//////////////////////////////////////////////////////////

using System;
using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.UI;

public class Placement : MonoBehaviour
{
    public Transform currentPreview;
    public Transform cam;
    public LayerMask layer;
    public float maxDist;
    private RaycastHit hit;
    private RaycastHit lastHit;
    private Vector3 currentPos;
    private PreviewObject previewObject;
    public Transform placeable;
    public Renderer rend;

    public Text overlayText;

    public bool isPlacing;

    private void Start()
    {
        rend = GetComponent<Renderer>();
        //placeable = GameObject.Find(gameObject.name).transform;
        currentPreview = transform;
        previewObject = currentPreview.GetComponent<PreviewObject>();
    }

    private void Update()
    {
        if (isPlacing)
        {
            StartPreview();
            if (Input.GetKeyDown(KeyCode.R))
            {
                currentPreview.Rotate(0.0f, 90.0f, 0.0f);
                AkSoundEngine.PostEvent("turnItem", gameObject);
            }
        }
    }

    public void StartPreview()
    {
        overlayText.text = "Press Left Mouse Button to place \n\n Press \"R\" to rotate object";
        if (Physics.Raycast(cam.position, cam.forward, out hit, maxDist, layer))
        {
            if (hit.transform != this.transform && gameObject.name != "Drone")
            {
                previewObject.ChangeColor("Green");
                ShowPreview(hit);
                if (Input.GetMouseButtonDown(0))
                {
                    Place();
                    AkSoundEngine.PostEvent("craftItem", gameObject);
                }
            }

            if (gameObject.name == "Drone")
            {
                transform.position = hit.transform.position;
                hit.transform.GetComponent<Renderer>().material = previewObject.green;
                previewObject.ChangeColor("Green");
                if (Input.GetMouseButtonDown(0))
                {
                    Place();
                    AkSoundEngine.PostEvent("craftItem", gameObject);
                }
            }
            lastHit = hit;
        }
        else
        {
            transform.position = cam.position + cam.forward * maxDist;
            if(gameObject.name == "Drone")
                lastHit.transform.GetComponent<Renderer>().material = previewObject.red;
            previewObject.ChangeColor("Red");
        }
    }

    public void ShowPreview(RaycastHit hit2)
    {
        currentPreview.position = hit2.point;
        //currentPreview.position = currentPos;
    }

    public void Place()
    {
        placeable.position = currentPreview.position;
        placeable.rotation = currentPreview.rotation;
        currentPreview.position = new Vector3(0.0f, -100.0f, 0.0f);
        overlayText.text = "";
        isPlacing = false;
        if (gameObject.name == "Drone")
            Drone.placed = true;
    }

    public void FindPlaceableObject()
    {
        placeable = GameObject.Find("/"+gameObject.name).transform;
    }
}
