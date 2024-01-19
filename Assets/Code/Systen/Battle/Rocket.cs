using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocket : MonoBehaviour
{
    public Rigidbody2D rb;
    Team Thisteam;
    public Transform target;
    private bool startAim = false;
    public int ID;
    private void Start()
    {
        ID = Spawn_Rocket.ID;
        target = Spawn_Rocket.Target[ID];
        rb.velocity = Vector2.up * 20;
        StartCoroutine(De());
    }
    
    IEnumerator De()
    {
        yield return new WaitForSeconds(3);
        startAim = true;
    }
    private void FixedUpdate()
    {
        if (startAim)
        {
            Aim();
        }
    }

    public void Aim()
    {
        Vector3 vectorToTarget = target.transform.position - transform.position;
        float angle = Mathf.Atan2(vectorToTarget.y, vectorToTarget.x) * Mathf.Rad2Deg - 90;
        Quaternion q = Quaternion.AngleAxis(angle, Vector3.forward);
        transform.rotation = Quaternion.Slerp(transform.rotation, q, Time.deltaTime * 0.1f);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Unit")
        {
            if (Thisteam != collision.gameObject.GetComponent<ITeam>().CTeam())
            {
                Destroy(collision.gameObject);
                Destroy(gameObject);
            }
        }
    }
}
