using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Check_Limit : MonoBehaviour
{
    public static bool LimitE = false;
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Unit")
        {
            LimitE = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Unit")
        {
            LimitE = false;
        }
    }
}
