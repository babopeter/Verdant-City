using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float m_JumpSpeed;
    [SerializeField] private float m_GravityMultiplier;
    
    public float movementSpeed;
    public AkEvent footstepSound;
    private CharacterController m_CharacterController;
    private CollisionFlags m_CollisionFlags;
    private Vector3 m_MoveDir = Vector3.zero;
    private bool m_Jump;
    private bool m_Jumping;
    private Vector2 m_Input = Vector2.zero;
    private bool m_PreviouslyGrounded;

    public Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        m_Jumping = false;
        m_CharacterController = GetComponent<CharacterController>();
        anim = GetComponent<Animator>();
        AkSoundEngine.PostEvent("Ambience", gameObject);
        AkSoundEngine.SetState(3826569560U, 1216605696U);
    }

    private void Update()
    {
        if (!m_Jump)
        {
            m_Jump = Input.GetButtonDown("Jump");
        }

        if (!m_PreviouslyGrounded && m_CharacterController.isGrounded)
        {
            m_MoveDir.y = 0f;
            m_Jumping = false;
        }
        if (!m_CharacterController.isGrounded && !m_Jumping && m_PreviouslyGrounded)
        {
            m_MoveDir.y = 0f;
        }
        m_PreviouslyGrounded = m_CharacterController.isGrounded;
    }

    void FixedUpdate()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        
        m_Input = new Vector2(horizontal, vertical);
        
        Vector3 desiredMove = transform.forward*m_Input.y + transform.right*m_Input.x;
        
        RaycastHit hitInfo;
        //Physics.SphereCast(transform.position, m_CharacterController.radius, Vector3.down, out hitInfo,
            //m_CharacterController.height/2f, Physics.AllLayers, QueryTriggerInteraction.Ignore);
        //desiredMove = Vector3.ProjectOnPlane(desiredMove, hitInfo.normal).normalized;

        if(Input.GetAxis("Vertical") < 0 || Input.GetAxis("Vertical") > 0 || Input.GetAxis("Horizontal") < 0 || Input.GetAxis("Horizontal") > 0)
        {
            anim.SetBool("isWalking", true);
        } else
        {
            anim.SetBool("isWalking", false);
        }
        
        /*
        float zTravel = Input.GetAxis("Vertical") * movementSpeed;
        float xTravel = Input.GetAxis("Horizontal") * movementSpeed;
        */
        
        m_MoveDir.x = desiredMove.x * movementSpeed;
        m_MoveDir.z = desiredMove.z * movementSpeed;
        
        if (m_CharacterController.isGrounded)
        {

            if (m_Jump)
            {
                m_MoveDir.y = m_JumpSpeed;
                m_Jump = false;
                m_Jumping = true;
            }
        }
        else
        {
            m_MoveDir += Physics.gravity*m_GravityMultiplier*Time.fixedDeltaTime;
        }

        // Make it move 10 meters per second instead of 10 meters per frame...
        /*
        zTravel *= Time.fixedDeltaTime;
        xTravel *= Time.fixedDeltaTime;
        */
        //rotation *= Time.deltaTime;

        /*
        if (Input.GetKeyDown("space"))
        {
            transform.Translate(Vector3.up * 100 * Time.deltaTime, Space.World);
        }
        */

        // Move translation along the object's z-axis
        //transform.Translate(xTravel, 0, zTravel);
        
        m_CollisionFlags = m_CharacterController.Move(m_MoveDir*Time.fixedDeltaTime);

        // Rotate around our y-axis
        //transform.Rotate(0, rotation, 0);
    }
    
    //function for handling footsteps
    void AnimFootstep()
    {
        if (footstepSound != null)
        {
            footstepSound.HandleEvent(gameObject);
        }
    }
}
