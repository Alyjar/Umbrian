using UnityEngine;

public class SCR_Movement : MonoBehaviour
{
    [Header("Movement Settings")]
    public float moveSpeed;
    public float jumpForce;
    private Vector3 moveDirection;
    public float sprintModifier;
    public float gravityScale;
    private CharacterController playerCharacterController;

    private void Start() 
    {
        playerCharacterController = GetComponent<CharacterController>();
    }

    private void Update()
    {
        float yStore = moveDirection.y;

        if(playerCharacterController.isGrounded)
        {           

            if(Input.GetKey(KeyCode.LeftShift))
            {
                moveDirection = (transform.forward * Input.GetAxisRaw("Vertical")) + transform.right * Input.GetAxisRaw("Horizontal");
                moveDirection = moveDirection.normalized * moveSpeed * sprintModifier;


            }
            else
            {
                moveDirection = (transform.forward * Input.GetAxisRaw("Vertical")) + transform.right * Input.GetAxisRaw("Horizontal");
                moveDirection = moveDirection.normalized * moveSpeed;
            }

            if(Input.GetButtonDown("Jump"))
            {
                moveDirection.y = jumpForce;
                Debug.Log("Jumped");
            } 

        }

        
        moveDirection.y = moveDirection.y + (Physics.gravity.y * gravityScale * Time.deltaTime);
        playerCharacterController.Move(moveDirection * Time.deltaTime);

    }
}
