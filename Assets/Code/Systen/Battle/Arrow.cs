using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Transform Target;
    private Vector3 start;
    private Vector3 control;
    private float sampletime;
    public float speed;
    public Team Thisteam;
    public float Dmg;
    private bool del = false;
    // Start is called before the first frame update
    void Start()
    {
        sampletime = 0f;
        start = transform.position;        

    }
    private void Update()
    {
        if (del)
        {
            if (Target = null)
            {
                Destroy(gameObject);
            }
        }
    }

    void FixedUpdate()
    {
        if (Target == null)
        {
            rb.velocity = transform.right * 10;
            return;
        }
        control = new Vector3(center(start.x, Target.position.x), start.y + 10, start.z);
        transform.up = evaluate(sampletime + 0.001f) - transform.position;

        sampletime += Time.deltaTime * speed;
        transform.position = evaluate(sampletime);
        transform.right = evaluate(sampletime + 0.001f) - transform.position;

    }

    public Vector3 evaluate(float t)
    {
        Vector3 ac = Vector3.Lerp(start, control, t);
        Vector3 cb = Vector3.Lerp(control, Target.position, t);
        return Vector3.Lerp(ac, cb, t);
    }

    public void SetTarget(Transform tar)
    {
        Target = tar;
    }

    public float center(float x1,float x2)
    {
        float X =Mathf.Abs(x1 - x2);
        X /= 4;
        if (x1 > x2)
        {
            X *= -1;
        }
        X += x1;
        return X;
    }

    public float high(float x1, float x2)
    {
        float X = Mathf.Abs(x1 - x2);
        X /= 5;
        return X;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Unit")
        {
            if (Thisteam!=collision.gameObject.GetComponent<ITeam>().CTeam())
            {
                collision.gameObject.GetComponent<IDamagable>().Damage(Dmg);
                Destroy(gameObject);
            }
        }
        if (collision.gameObject.tag == "Tower")
        {
            if (Thisteam != collision.gameObject.GetComponent<ITeam>().CTeam())
            {
                collision.gameObject.GetComponent<IDamagable>().Damage(Dmg);
                Destroy(gameObject);
            }
        }
        if (collision.gameObject.name == "Land")
        {

            Destroy(gameObject);

        }
    }

    IEnumerable Cooldown()
    {
        yield return new WaitForSeconds(0.2f);
        del = true;

    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
