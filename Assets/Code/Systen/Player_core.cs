using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_core : MonoBehaviour
{
    public static int Money = 20;
    public static int Money_Max = 100;
    public static float Cooldown = 0.2f;
    float Timer=0;

    private void Update()
    {
        Timer += Time.deltaTime;
        if (Timer >= Cooldown)
        {
            if (Money<Money_Max)
            {
                Money +=1;
            }
            Timer = 0;
        }
    }

    public static void upgrade()
    {
        Money_Max += 15;
        Cooldown /= 1.2f;
    }

    public static void MinusMoney(int Num)
    {
        Money -= Num;
    }
}
