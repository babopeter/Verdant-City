//////////////////////////////////////////////////////////
///Source: https://www.youtube.com/watch?v=7nxpDwnU0uU ///
//////////////////////////////////////////////////////////

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPMouseLook : MonoBehaviour
{
    public Transform player, face;
    Vector2 rotation = new Vector2(0, 0);
    private Quaternion playerRotation;

    [Range(0.1f, 10.0f)]
    public float sensitivity;

    void Update()
    {
        rotation.y += Input.GetAxis("Mouse X");
        rotation.x += -Input.GetAxis("Mouse Y");
        rotation.x = Mathf.Clamp(rotation.x, -40f, 40f);
        transform.eulerAngles = (Vector2)rotation * sensitivity;
        playerRotation = transform.rotation;
        playerRotation.x = 0;
        playerRotation.z = 0;
        //player.transform.rotation = playerRotation;
    }

    private void FixedUpdate()
    {
        player.transform.rotation = playerRotation;
    }
}
