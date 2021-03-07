using UI;
using UnityEngine;

public class SCR_Camera : MonoBehaviour
{
    [Header("References")]
    [Tooltip("Camera's target")]
    public Transform target;
    public Transform pivot;
    [Header("Camera Settings")]
    [Tooltip("Speed at which the player can move the camera")]
    public float rotateSpeed = 5f;
    [Tooltip("Maximum angle the camera is allowed to move to")]
    public float maxViewAngle;
    [Tooltip("Minimum angle the camera is allowed to move to")]
    public float minViewAngle;  
    [Tooltip("Whether the camera should make its own offset dependent on location (off) or if it should use the provided values (on)")]
    public bool useOffsetValues;
    [Tooltip("Offset of the camera from the player")]
    public Vector3 offset;
    [Tooltip("Offset of where the pivot is placed from the player location")]
    public Vector3 pivotOffset;
    public PauseUIManager uiScript;

    private Quaternion rotation;
    private RaycastHit hit;

    void Start() 
    {
        if(!useOffsetValues)
        {
            offset = target.position - transform.position;
        }

        Cursor.lockState = CursorLockMode.Locked;

        pivot.position = target.position + pivotOffset;
        pivot.transform.parent = target;

        uiScript = uiScript.GetComponent<PauseUIManager>();
    }

    void LateUpdate()
    {
        if (!uiScript.pausePressed)
        {
            // Get the X position of the mouse and rotate the target
            float horizontal = Input.GetAxis("Mouse X") * rotateSpeed;
            target.Rotate(0, horizontal, 0);

            // Get the Y position of the mouse and rotate the pivot
            float vertical = Input.GetAxis("Mouse Y") * rotateSpeed;
            pivot.Rotate(-vertical, 0, 0);

            // Limit up/down camera rotation
            if (pivot.rotation.eulerAngles.x > maxViewAngle && pivot.rotation.eulerAngles.x < 180f)
            {
                pivot.rotation = Quaternion.Euler(maxViewAngle, 0, 0);
            }

            if (pivot.rotation.eulerAngles.x > 180f && pivot.rotation.eulerAngles.x < 360 + minViewAngle)
            {
                pivot.rotation = Quaternion.Euler(360f + minViewAngle, 0, 0);
            }

            // Move the camera based on the current rotation of the target and the original offset
            float desiredYAngle = target.eulerAngles.y;
            float desiredXAngle = pivot.eulerAngles.x;
            rotation = Quaternion.Euler(desiredXAngle, desiredYAngle, 0);
            transform.position = target.position - (rotation * offset);

            if (transform.position.y < target.position.y)
            {
                transform.position = new Vector3(transform.position.x, target.position.y - .5f, transform.position.z);
            }

            transform.LookAt(pivot);

            HandleCollisions();
        }
    }

    void HandleCollisions()
    {
        if (Physics.Linecast(transform.position, target.position, out hit))
        {
            if (!hit.collider.gameObject.CompareTag("Player"))
            {
                Debug.Log("Hitting object");
                transform.localPosition = new Vector3(pivot.position.x ,pivot.position.y ,pivot.position.z);
            }          
            
        }
        
    }
}
