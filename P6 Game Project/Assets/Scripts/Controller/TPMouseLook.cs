//////////////////////////////////////////////////////////
///Source: https://www.youtube.com/watch?v=7nxpDwnU0uU ///
//////////////////////////////////////////////////////////

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TPMouseLook : MonoBehaviour
{
    public Transform player, target;

    private float xRot = 0.0f;
    private float yRot = 0.0f;
    [Range(0.1f, 10.0f)]
    public float sensitivity;

    void LateUpdate()
    {
        xRot += Input.GetAxis("Mouse X") * sensitivity;
        yRot -= Input.GetAxis("Mouse Y") * sensitivity;
        yRot = Mathf.Clamp(yRot, -5, 89);

        transform.LookAt(target);

        target.rotation = Quaternion.Euler(yRot, xRot, 0);

        player.transform.rotation = Quaternion.Euler(0, xRot, 0);
    }
}
