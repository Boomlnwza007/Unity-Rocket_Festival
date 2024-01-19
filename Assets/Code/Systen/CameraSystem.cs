using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSystem : MonoBehaviour
{
    [SerializeField]private Camera cam;

    private bool DragMoveCam;
    private Vector2 LastMousePosition;
    [SerializeField] private float minDrag;
    [SerializeField] private float maxDrag;

    private void FixedUpdate()
    {
        Move();
    }
    private void Update()
    {
        CamMove();
    }
    private void CamMove()
    {        
        if (Input.GetMouseButtonDown(1))
        {
            DragMoveCam = true;
            LastMousePosition = Input.mousePosition;
        }
        if (Input.GetMouseButtonUp(1))
        {
            DragMoveCam = false;
        }

    
    }

    public void Move()
    {
        Vector3 InputDir = new Vector3(0, 0, 0);
        if (DragMoveCam)
        {
            Vector2 mouseMoveDelta = (Vector2)Input.mousePosition - LastMousePosition;

            float dragSpeed = 1f;
            InputDir.x = -mouseMoveDelta.x * dragSpeed;


            LastMousePosition = Input.mousePosition;
        }


        Vector3 moveDir = transform.right * InputDir.x;

        float moveSpeed = 1.5f;
        transform.position = ClampCam(transform.position + moveDir * moveSpeed * Time.deltaTime);
    }

    private Vector3 ClampCam(Vector3 target)
    {
        float NewX = Mathf.Clamp(target.x, minDrag, maxDrag);
        return new Vector3(NewX, target.y, target.z);
    }

}
