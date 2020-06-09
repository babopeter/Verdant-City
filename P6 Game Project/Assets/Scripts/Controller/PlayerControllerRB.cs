using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerControllerRB : MonoBehaviour
{
    Rigidbody rb;
    // set the value great 100
    public float speed;
    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {

        float deltaX = Input.GetAxis("Horizontal") * speed;
        float deltaZ = Input.GetAxis("Vertical") * speed;
        Vector3 movement = new Vector3(deltaX, 0, deltaZ);
        // Returns a copy of vector with its magnitude clamped to maxLength
        //movement = Vector3.ClampMagnitude(movement, speed);

        movement *= Time.deltaTime;
        // Transforms direction from local space to world space.
        movement = transform.TransformDirection(movement);
        rb.AddForce(movement);
    }
}
