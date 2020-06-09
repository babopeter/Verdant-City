using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TPOrFP : MonoBehaviour
{
    public bool TP;
    public GameObject FPPlayer, TPPlayer;
    // Update is called once per frame
    void Update()
    {
        if(TP)
        {
            FPPlayer.SetActive(false);
            TPPlayer.SetActive(true);
        } else
        {
            FPPlayer.SetActive(true);
            TPPlayer.SetActive(false);
        }
    }
}
