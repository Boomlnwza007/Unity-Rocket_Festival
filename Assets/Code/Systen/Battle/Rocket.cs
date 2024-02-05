using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocket : MonoBehaviour
{
    public Rigidbody2D rb;
    public Team Thisteam;
    public Vector3 target;
    private bool startAim = false;
    public GameObject Expo;
    private void Start()
    {
        target = Spawn_Rocket.End_point.position;
        float distan = Spawn_Rocket.distan;
        float a = Random.Range(10,distan);
        target.x = target.x+a;
        rb.velocity = transform.up * 40;
        StartCoroutine(De());
    }
    
    IEnumerator De()
    {
        yield return new WaitForSeconds(2);
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
        rb.velocity = transform.up * 20;
        if (transform.position.y < 0)
        {
            return;
        }
        Vector3 vectorToTarget = target - transform.position;
        float angle = Mathf.Atan2(vectorToTarget.y, vectorToTarget.x) * Mathf.Rad2Deg - 90;
        Quaternion q = Quaternion.AngleAxis(angle, Vector3.forward);
        transform.rotation = Quaternion.Slerp(transform.rotation, q, Time.deltaTime * 5f);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Land")
        {

            Destroy(gameObject);
            Instantiate(Expo,gameObject.transform.position,Quaternion.identity);
            
        }
        if (collision.gameObject.tag == "Unit")
        {
            if (collision.gameObject.GetComponent<ITeam>().CTeam()!=Thisteam)
            {
                collision.gameObject.GetComponent<IDamagable>().Damage(100);                
            }           

        }
    }
}
