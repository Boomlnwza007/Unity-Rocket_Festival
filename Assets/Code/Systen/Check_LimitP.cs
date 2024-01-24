using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Check_LimitP : MonoBehaviour
{
    public static bool Limit = false;
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Unit")
        {
            Limit = true;
        }        
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Unit")
        {
            Limit = false;
        }
    }
}
