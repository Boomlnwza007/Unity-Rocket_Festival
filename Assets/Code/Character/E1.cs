using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class E1 : UnitBase, IDamagable , ITeam
{
    Vector2 dir;
    [SerializeField] Rigidbody2D rb;
    public float distanceAttack = 2.5f;
    [SerializeField] private bool attacking = false;
    private bool attack = false;
    [SerializeField] private bool Move = true;
    public HPBar hpbar;
    [SerializeField]private Transform ray;

    private void Awake()
    {
        hpbar.SetMaxHp(Hp);
        rb = gameObject.GetComponent<Rigidbody2D>();
        if (Thisteam == Team.Player)
        {
            dir = Vector2.right;
        }
        else
        {
            dir = Vector2.left;
        }
    }
    private void Update()
    {

        Dead();
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        
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
        AnimeControl();
    }

    public void move()
    {
        rb.velocity = dir * SpMove;
    }

    public void Attack()
    {
        RaycastHit2D[] Enemy = Physics2D.RaycastAll(ray.transform.position, dir, distanceAttack);
        foreach (var item in Enemy)
        {
           
            if (item.collider.name != gameObject.name)
            {
                if (item.collider.tag == "Unit")
                {
                    if (Thisteam != item.collider.GetComponent<ITeam>().CTeam())
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
        RaycastHit2D[] Enemy = Physics2D.RaycastAll(ray.transform.position, dir,2.2f);
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
        Vector3 vector3 = new Vector3(dir.x,dir.y,0);
        Gizmos.DrawLine(ray.transform.position, ray.transform.position + vector3 * distanceAttack);
    }


    IEnumerator Attack(RaycastHit2D G)
    {        
        if (!attack)
        {
            //Debug.Log(G.collider.name);
            attack = true;
            animetor.SetBool("Attack",true);
            yield return new WaitForSeconds(0.7f);
            animetor.SetBool("Attack", false);
            G.collider.GetComponent<IDamagable>().Damage(Dmg);            
            yield return new WaitForSeconds(CcDmg);
            attack = false;          
            
        }

    }

    public void Damage(float damage)
    {
        Hp -= damage;
        hpbar.SetHp(Hp);
    }

    public void Dead()
    {
        if (Hp <= 0)
        {
            Destroy(gameObject);
            if (Thisteam == Team.Enemy)
            {
                Player_core.Money += Random.Range(10,15);
                Player_core.Money = Mathf.Clamp(Player_core.Money,0,Player_core.Money_Max);
            }
        }
    }



    public void AnimeControl()
    {
        if (Move)
        {
            if (!attacking)
            {
                animetor.SetBool("Walk", true);
            }
            else
            {
                animetor.SetBool("Walk", false);
            }
        }
        else
        {
            animetor.SetBool("Walk", false);
        }
    }

    public Team CTeam()
    {
        return Thisteam;
    }
}
