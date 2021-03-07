using UnityEngine;

public class SCR_SpellPivotRotation : MonoBehaviour
{

    public Transform cameraTransform;
    public Camera mainCamera;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Ray rayOrigin = mainCamera.ScreenPointToRay(Input.mousePosition);
        RaycastHit hitInfo;

        if(Physics.Raycast(rayOrigin, out hitInfo))
        {
            if(hitInfo.collider != null)
            {
                Vector3 direction = hitInfo.point - transform.position;
                transform.rotation = Quaternion.LookRotation(direction);
            }
        }

        else
        {
            transform.rotation = cameraTransform.rotation;
        }
    }
}
