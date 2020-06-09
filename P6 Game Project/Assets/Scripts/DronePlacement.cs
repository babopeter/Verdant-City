using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DronePlacement : MonoBehaviour
{
    public Material green;
    public Material red;
    public MissionWaypoint missionWaypoint;
    public Renderer rend;

    private void Start()
    {
        //missionWaypoint.target = transform;
        rend = GetComponent<Renderer>();
        missionWaypoint = GameObject.Find("Player/Camera").GetComponent<MissionWaypoint>();
    }
    
    private void Update()
    {
        if (Drone.placed)
        {
            Destroy(gameObject);
        }
    }
}
