using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MissionWaypoint : MonoBehaviour
{
    public Image img;
    public Transform target;
    public Text meter;
    public Vector3 offset;
    private float minX, maxX, minY, maxY;
    private Camera cam;
    public bool active = true;
    

    private void Start()
    {
        // Limit screen position so it always shows up on the side
        minX = img.GetPixelAdjustedRect().width / 2;
        maxX = Screen.width - minX;
        minY = img.GetPixelAdjustedRect().height / 2;
        maxY = Screen.height - minY;
        cam = Camera.main;
    }

    private void LateUpdate()
    {
        if (active)
        {
            Vector2 pos = cam.WorldToScreenPoint(target.position + offset);
        
            // To know if the object is behind the camera or not
            if (Vector3.Dot((target.position - transform.position), transform.forward) < 0)
            {
                if (pos.x < Screen.width / 2)
                {
                    pos.x = maxX;
                }
                else
                {
                    pos.x = minX;
                }
            }
        
            pos.x = Mathf.Clamp(pos.x, minX, maxX);
            pos.y = Mathf.Clamp(pos.y, minY, maxY);

            img.transform.position = pos;
            meter.text = ((int)Vector3.Distance(target.position, transform.position)).ToString() + "m";   
        }
        else
        {
            img.enabled = false;
            meter.enabled = false;
            Destroy(this);
        }
    }

}
