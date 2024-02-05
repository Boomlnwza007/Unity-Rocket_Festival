using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class UpGrade : MonoBehaviour
{
    public TMP_Text TMP_Text;
    public int Cost = 50;
    public Slider CoolDown;
    [SerializeField] Button button;
    public float CcUpGrade = 10;
    private int Level = 0;


    private void Awake()
    {
        CoolDown.maxValue = CcUpGrade;
        CoolDown.value = CoolDown.maxValue;
        TMP_Text.text = Cost + " LV. " + Level;
    }

    public void UpGradePlus()
    {
        if (Cost <= Player_core.Money)
        {
            Sound.playSound();
            Player_core.MinusMoney(Cost);           
            Player_core.upgrade();
            Level++;
            CoolDown.maxValue *= 1.5f;
            CoolDown.value = CoolDown.maxValue;            
            Cost += 15;
            CcUpGrade *= 1.5f;
            TMP_Text.text = Cost + " LV. "+ Level;
        }
        
    }

    private void Update()
    {
        ButtomOnOFf();
    }

    public void ButtomOnOFf()
    {
        if (CoolDown.value != 0)
        {
            CoolDown.value -= Time.deltaTime;
            button.enabled = false;
        }
        else if (CoolDown.value <= 0)
        {
            button.enabled = true;
        }
    }
}
