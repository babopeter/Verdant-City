using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drone : MonoBehaviour
{
    public Transform craftingTable;
    public Vector3 animationStartingPoint;
    private Vector3 initialMovePoint;
    private bool animationPointReached = false;
    private bool initialMove = false;
    private bool nextMove = false;
    public GameObject tree;
    private bool plantTree = false;
    public Animation anim;
    public bool soundPlayed;
    public HandleObjective handleObjective;
    public MissionWaypoint missionWaypoint;
    public Renderer dronePlacementRend;
    public GameObject preview;
    public Placement placement;
    public static bool placed = false;
    private bool anim1HasPlayed = false;

    void Start()
    {
        preview = GameObject.Find("Previews/Drone");
        gameObject.name = "Drone";
        placement = preview.GetComponent<Placement>();
        placement.FindPlaceableObject();
        placement.isPlacing = true;
        GameObject dronePlacementObject = GameObject.Find("DronePlacement");
        dronePlacementRend = dronePlacementObject.GetComponent<Renderer>();
        dronePlacementRend.enabled = true;
        missionWaypoint = GameObject.Find("Player/Camera").GetComponent<MissionWaypoint>();
        missionWaypoint.target = dronePlacementObject.transform;
        handleObjective = GameObject.Find("Canvas/Objective Panel").GetComponent<HandleObjective>();
        craftingTable = GameObject.Find("/Crafting Table").transform;
        //transform.position = new Vector3(craftingTable.position.x, craftingTable.position.y + 1.15f, craftingTable.position.z);
        //initialMovePoint = new Vector3(transform.position.x, transform.position.y + 1.0f, transform.position.z);
        //StartCoroutine(InitialMove(2));
        AkSoundEngine.PostEvent("droneOn", gameObject);
    }

    private void Update()
    {
        if (handleObjective.objective[4].isActive)
        {
            handleObjective.CompleteObjective();
        }
        if (placed && !anim1HasPlayed)
        {
            if (handleObjective.objective[5].isActive)
            {
                handleObjective.CompleteObjective();
            }
            missionWaypoint.target = transform;
            HandleLife.dronePlaced = true;
            anim.Play("Drone");
            anim1HasPlayed = true;
            StartCoroutine(PlantTree(1f));
        }

        RaycastHit deadHit;
        if (Physics.SphereCast(transform.position, 10f, Vector3.down, out deadHit, Mathf.Infinity))
        {
            if (deadHit.transform.CompareTag("Dead"))
            {
                Destroy(deadHit.transform.gameObject);
            }
        }
        
        if (plantTree && anim.isPlaying)
        {
            RaycastHit hit;
            if (Physics.Raycast(transform.position, Vector3.down, out hit, Mathf.Infinity))
            {
                if (hit.transform.CompareTag("Grass"))
                {
                    Instantiate(tree, new Vector3(UnityEngine.Random.Range(transform.position.x- 2.0f, transform.position.x + 2.0f), 
                        0.0f, UnityEngine.Random.Range(transform.position.z - 5.0f, transform.position.z + 5.0f)), Quaternion.identity);
                }
            }
            plantTree = false;
            StartCoroutine(PlantTree(1f));
        }
    }
    
    
    
    IEnumerator PlantTree(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        plantTree = true;
    }

    /*
    // Update is called once per frame
    void Update()
    {
        if (handleObjective.objective[4].isActive)
        {
            handleObjective.CompleteObjective();
        }
        if (initialMove)
        {
            transform.position = Vector3.MoveTowards(transform.position, initialMovePoint, 1f * Time.deltaTime);
            if (transform.position == initialMovePoint)
            {
                initialMove = false;
                StartCoroutine(NextMove(1));
            }
        }
        if (nextMove)
        {
            transform.position = Vector3.MoveTowards(transform.position, animationStartingPoint, 2 * Time.deltaTime);
            if (transform.position == animationStartingPoint && !animationPointReached)
            {
                animationPointReached = true;
                anim.Play("Drone");
                StartCoroutine(WaitForAnimation(5));
                nextMove = false;
            }
        }

        if (plantTree && anim.isPlaying)
        {
            StartCoroutine(PlantTree(0.5f));
            Instantiate(tree, new Vector3(Random.Range(transform.position.x- 5.0f, transform.position.x + 5.0f), 
                0.0f, Random.Range(transform.position.z - 5.0f, transform.position.z + 5.0f)), Quaternion.identity);
            plantTree = false;
        }
    }

    IEnumerator InitialMove(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        initialMove = true;
    }

    IEnumerator NextMove(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        nextMove = true;
    }

    IEnumerator WaitForAnimation(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        StartCoroutine(PlantTree(2));
    }

    IEnumerator PlantTree(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        plantTree = true;
    }
    */
}
