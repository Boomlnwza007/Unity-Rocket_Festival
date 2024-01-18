using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum TypeCharacter
{
    Melee, Range,Tank
}
public enum Team
{
    Player, Enemy
}
public abstract class UnitBase : MonoBehaviour
{
    public Animator animetor;
    public TypeCharacter Type;
    public Team Thisteam;
    public float Hp = 2;
    public float Dmg = 2;
    public float CcDmg = 2;
    public float SpMove = 5;
    public float CcSpawn = 3;
    public int Cost = 30;
}
