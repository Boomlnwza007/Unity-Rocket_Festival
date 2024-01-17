using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocket : MonoBehaviour
{
    public Rigidbody2D rb;
    private void Start()
    {
        rb.velocity = Vector2.up * 20;
    }

    IEnumerator De()
    {
        yield return new WaitForSeconds(3);
        Destroy(gameObject);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (true)
        {

        }
    }
}
