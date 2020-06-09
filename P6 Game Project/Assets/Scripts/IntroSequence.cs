using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntroSequence : MonoBehaviour
{
    public GameObject player;
    public GameObject playerModel;
    private SkinnedMeshRenderer playerRend;
    public GameObject playerCamera;
    public GameObject canvas;
    public GameObject waypointCanvas;
    public GameObject barPanel;
    public GameObject objectiveNotification;

    private Animator anim;
    // Start is called before the first frame update

    private void Awake()
    {
        
    }

    private void Start()
    {
        AkSoundEngine.PostEvent("Intro", gameObject);
        playerRend = playerModel.GetComponent<SkinnedMeshRenderer>();
        player.GetComponent<PlayerController>().enabled = false;
        player.GetComponent<HandleInput>().enabled = false;
        barPanel.SetActive(false);
        playerCamera.SetActive(false);
        playerRend.shadowCastingMode = UnityEngine.Rendering.ShadowCastingMode.On;
        canvas.GetComponent<Canvas>().enabled = false;
        //waypointCanvas.GetComponent<Canvas>().enabled = false;
        anim = gameObject.GetComponent<Animator>();
        objectiveNotification.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (anim.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1)
        {
            EnablePlayer();
        }
    }

    public void EnablePlayer()
    {
        player.GetComponent<PlayerController>().enabled = true;
        player.GetComponent<HandleInput>().enabled = true;
        playerCamera.SetActive(true);
        canvas.GetComponent<Canvas>().enabled = true;
        barPanel.SetActive(true);
        playerRend.shadowCastingMode = UnityEngine.Rendering.ShadowCastingMode.ShadowsOnly;
        objectiveNotification.SetActive(true);
        AkSoundEngine.PostEvent("Objective_New", gameObject);
        //waypointCanvas.GetComponent<Canvas>().enabled = true;
        gameObject.SetActive(false);
    }
}
