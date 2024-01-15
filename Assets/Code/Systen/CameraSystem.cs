using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSystem : MonoBehaviour
{
    [SerializeField]private Camera cam;
    private float zoom;
    private float zoomMultiplier = 4;
    private float minZoom = 2f;
    private float maxZoom = 10f;
    private float velocity = 0f;
    private float smoothTime = 0.25f;

    private bool DragMoveCam;
    private Vector2 LastMousePosition;
    [SerializeField] private float minDrag;
    [SerializeField] private float maxDrag;

    private void Start()
    {
        zoom = cam.orthographicSize;
    }
    private void FixedUpdate()
    {
        //if (!DragMoveCam)
        //{
        //    CamZoom();
        //}
        CamMove();
    }

    private void CamMove()
    {
        Vector3 InputDir = new Vector3(0, 0, 0);
        if (Input.GetMouseButtonDown(1))
        {
            DragMoveCam = true;
            LastMousePosition = Input.mousePosition;
        }
        if (Input.GetMouseButtonUp(1))
        {
            DragMoveCam = false;
        }

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

    public void CamZoom()
    {
        Vector3 moveDir = new Vector3(0, 0, 0);
        float scroll = Input.GetAxis("Mouse ScrollWheel");
        moveDir.y += scroll * 10;
        zoom -= scroll * zoomMultiplier;

        zoom = Mathf.Clamp(zoom, minZoom, maxZoom);
        moveDir.y = Mathf.Clamp(moveDir.y, 0, 4);

        cam.orthographicSize = Mathf.SmoothDamp(cam.orthographicSize, zoom, ref velocity, smoothTime);    

        transform.position += moveDir * smoothTime * Time.deltaTime;
    }

    private Vector3 ClampCam(Vector3 target)
    {
        float NewX = Mathf.Clamp(target.x, minDrag, maxDrag);
        return new Vector3(NewX, target.y, target.z);
    }

}
