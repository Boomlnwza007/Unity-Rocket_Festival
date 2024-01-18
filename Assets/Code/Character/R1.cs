using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class R1 : UnitBase , IDamagable , ITeam
{
    Vector2 dir;
    [SerializeField] Rigidbody2D rb;
    public float distanceAttack = 2.5f;
    private bool attacking = false;
    private bool attack = false;
    private bool Move = true;
    public HPBar hpbar;
    [SerializeField] private GameObject arrow;
    [SerializeField] private Transform pointArrow;
    private GameObject target;

    private void Awake()
    {
        hpbar.SetMaxHp(Hp);
        rb = gameObject.GetComponent<Rigidbody2D>();
        if (Thisteam == Team.Player)
        {
            dir = Vector2.left;
        }
        else
        {
            dir = Vector2.right;
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Dead();
        LineSet();
        Attack();
        if (Move)
        {
            if (!attacking)
            {
                move();
            }
        }

        else
        {
            rb.velocity = Vector2.zero;
        }

    }

    public void move()
    {
        rb.velocity = dir * SpMove;
    }

    public void Attack()
    {
        RaycastHit2D[] Enemy = Physics2D.RaycastAll(this.transform.position, dir, distanceAttack);
        foreach (var item in Enemy)
        {

            if (item.collider.name != gameObject.name)
            {
                if (item.collider.tag == "Unit")
                {
                    if (!item.collider.GetComponent<ITeam>().CTeam(Thisteam))
                    {
                        attacking = true;
                        StartCoroutine(Attack(item));
                        //Debug.Log("Hit P");
                    }
                    else
                    {
                        attacking = false;
                    }
                }
                else if (item.collider.tag == "Tower")
                {
                    if (item.collider.GetComponent<Tower>().Thisteam != Thisteam)
                    {
                        attacking = true;
                        StartCoroutine(Attack(item));
                        // Debug.Log("Hit T");
                    }
                    else
                    {
                        attacking = false;
                    }
                }

            }
            else
            {
                attacking = false;

            }
        }
    }

    public void LineSet()
    {
        RaycastHit2D[] Enemy = Physics2D.RaycastAll(this.transform.position, dir, 2.2f);
        foreach (var item in Enemy)
        {
            if (item.collider != gameObject.GetComponent<Collider2D>())
            {
                if (item.collider.tag == "Unit")
                {
                    Move = false;
                }
                else if (item.collider.tag == "Tower")
                {
                    if (item.collider.GetComponent<Tower>().Thisteam != Thisteam)
                    {
                        Move = false;

                    }
                    else
                    {
                        Move = true;
                    }
                }
            }
            else
            {
                Move = true;
            }
        }
    }

    private void OnDrawGizmos()
    {
        Vector3 vector3 = new Vector3(dir.x, dir.y, 0);
        Gizmos.DrawLine(this.transform.position, this.transform.position + vector3 * distanceAttack);
    }


    IEnumerator Attack(RaycastHit2D G)
    {
        if (!attack)
        {
            //Debug.Log(G.collider.name);
            attack = true;
            yield return new WaitForSeconds(0.7f);
            Instantiate(arrow, pointArrow.position, Quaternion.identity);
            target = G.collider.gameObject;
            yield return new WaitForSeconds(CcDmg);
            attack = false;
        }

    }

    public void Damage(float damage)
    {
        Hp -= damage;
        hpbar.SetHp(Hp);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Arrow")
        {
            collision.gameObject.GetComponent<Arrow>().SetTarget(target.transform);
        }
    }

    public void Dead()
    {
        if (Hp <= 0)
        {
            Destroy(gameObject);
            if (Thisteam == Team.Enemy)
            {
                Player_core.Money += Random.Range(10, 15);
                Player_core.Money = Mathf.Clamp(Player_core.Money, 0, Player_core.Money_Max);
            }
        }
    }

    public bool CTeam(Team team)
    {
        bool y = false;
        if (team == Thisteam)
        {
            y = true;
        }
        return y;
    }
}
