using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Source: https://answers.unity.com/questions/19864/3rd-person-camera-collision.html
/// </summary>
public class CameraCollision : MonoBehaviour
{
    public float minDistance;
    public float maxDistance;
    public float smooth;
    Vector3 dollyDir;
    float distance;
    void Awake()
    {
        dollyDir = transform.localPosition.normalized;
        distance = transform.localPosition.magnitude;
    }
    void FixedUpdate()
    {
        Vector3 desiredCameraPos = transform.parent.TransformPoint(dollyDir * maxDistance);
        RaycastHit hit;
        if (Physics.Linecast(transform.parent.position, desiredCameraPos, out hit))
        {
            distance = Mathf.Clamp(hit.distance-0.1f, minDistance, maxDistance);
        }
        else
        {
            distance = maxDistance;
        }
        transform.localPosition = dollyDir * distance;
    }
}
