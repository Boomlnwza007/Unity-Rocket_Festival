using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public float FollowSpeed = 2f;
    public Transform Target;

    public float maxX;
    public float minX;

    private void FixedUpdate()
    {
        Vector3 Newpos = new Vector3(Target.position.x,0f,-10f);
        Newpos.x = Mathf.Clamp(Newpos.x,minX,maxX);
        transform.position = Vector3.Lerp(transform.position, Newpos, FollowSpeed);
    }
}
