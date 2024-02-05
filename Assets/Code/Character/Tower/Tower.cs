using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : TowerBase , IDamagable ,ITeam
{
    public HPBar HpBar;

    private void Awake()
    {
        HpBar.SetMaxHp(Hp);
    }
    public void Damage(float damage)
    {
        Hp -= damage;
        HpBar.SetHp(Hp);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public Team CTeam()
    {
        return Thisteam;
    }
}
