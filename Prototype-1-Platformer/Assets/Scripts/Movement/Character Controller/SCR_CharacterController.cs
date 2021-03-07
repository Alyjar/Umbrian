using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SCR_CharacterController : MonoBehaviour
{
    [Header("References")]
    private Rigidbody playersRigidbody;
    float xInput;
    float zInput;

    [Header("Movement Settings")]
    [Tooltip("How fast the player speeds up to their max speed. Don't make higher than the max speed.")]
    public float playerAcceleration;
    [Tooltip("The maximum speed that is achieveable without sprinting.")]
    public float maxPlayerSpeed;

    [Header("Sprint Settings")]
    [Tooltip("How much to multiply the playerSpeed variable by whilst the player is holding left shift.")]
    public float sprintModifier;
    [Tooltip("The maximum speed that is achieveable with sprinting.")]
    public float sprintMaxSpeed;
    private bool playerSprinting;

    [Header("Jump Settings")]
    [Tooltip("The force on the Y-axis given when the player jumps.")]
    public float jumpHeight;
    [Tooltip("The scale of gravity in the world, only changes on start.")]
    public float gravityScaleModifier;
    public float maxJumpHeight;
    private Collider playerCollider;
    private float distToGround;
    private bool playerIsGrounded;

    //Used to get data from objects the player looks at.
    public RayCastFwd rayFwd;

    private void Start()
    {
        playersRigidbody = GetComponent<Rigidbody>();
        Physics.gravity = Physics.gravity * gravityScaleModifier;
        playerCollider = this.GetComponent<Collider>();
        distToGround = playerCollider.bounds.extents.y;
    }

    private void Update()
    {
        CheckForSprint();
        JumpHandler();
        Interact();
    }

    private void FixedUpdate()
    {
        CheckForGrounded();
        MovementHandler();
    }


    /// <summary>
    /// Handles the player movement. This includes: Taking Inputs, Applying Input whilst taking rotation into account and multiplying it by the players speed.
    /// </summary>
    private void MovementHandler()
    {
        zInput = Input.GetAxisRaw("Vertical");
        xInput = Input.GetAxisRaw("Horizontal");

        Vector3 directionalInputs = transform.forward * zInput + transform.right * xInput;
        directionalInputs *= playerAcceleration;


        if (playerSprinting)
        {
            directionalInputs *= sprintModifier;
            directionalInputs = ClampVelocity(directionalInputs, sprintMaxSpeed);

            playersRigidbody.velocity = directionalInputs;
        } 
        else
        {
            directionalInputs = ClampVelocity(directionalInputs, maxPlayerSpeed);
            playersRigidbody.velocity = directionalInputs;
        }

        playersRigidbody.AddForce(directionalInputs, ForceMode.Force);

        //Debug.Log(directionalInputs);
    }

    private Vector3 ClampVelocity(Vector3 velocity, float speed)
    {
        velocity.x = Mathf.Clamp(velocity.x, -speed, speed);
        velocity.y = playersRigidbody.velocity.y;
        velocity.z = Mathf.Clamp(velocity.z, -speed, speed);

        return velocity;
    }

    private void JumpHandler()
    {

        if (playerIsGrounded && Input.GetButtonDown("Jump"))
        {
            // https://www.gamasutra.com/blogs/NielsTiercelin/20170807/303170/Unity_CHARACTER_CONTROLLER_vs_RIGIDBODY.php
            playersRigidbody.AddForce(Vector3.up * Mathf.Sqrt(jumpHeight * -2f * Physics.gravity.y), ForceMode.Impulse);          
        }
    }

    /// <summary>
    /// Checks whether the player is pressing the Left Shift key and changing the playerSprinting bool.
    /// </summary>
    private void CheckForSprint()
    {
        if (Input.GetKey(KeyCode.LeftShift))
        {
            playerSprinting = true;
        }
        else
        {
            playerSprinting = false;
        }
    }

    /// <summary>
    /// Uses a raycast to determine if the player is grounded or not.
    /// </summary>
    private void CheckForGrounded()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, Vector3.down, out hit, distToGround + 0.1f))
        {
           // Debug.Log("Grounded " + hit.transform.name);
            //Debug.Log("Slope Angle: " + (Vector3.Angle(hit.normal, Vector3.up)).ToString("N0") + "°");
            playerIsGrounded = true;
        }
        else
        {
            //Debug.Log("Not Grounded");
            playerIsGrounded = false;
        }
    }

    // Handles object interactions that use the E key
    private void Interact()
    {
        if (Input.GetKeyDown("e"))
        {
            if (rayFwd.hit.collider.gameObject.tag == "Tile")
            {
                rayFwd.hit.collider.gameObject.GetComponent<TileScript>().RotateTile();
            }
        }
    }

}
