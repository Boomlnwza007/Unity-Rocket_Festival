using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class ShowMoney : MonoBehaviour
{
    public TMP_Text Text;

    void Update()
    {
        Text.text = "Coin : "+Player_core.Money+"/"+Player_core.Money_Max;
    }
}
