using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HPBar : MonoBehaviour
{
    public Slider slider;
    private float health;
    public GameObject HpTop;
    private void Update()
    {
        if (slider.value != health)
        {
            slider.value = Mathf.Lerp(slider.value, health, 0.05f);
        }
    }
    public void SetMaxHp(float Hp)
    {
        slider.maxValue = Hp;
        slider.value = Hp;
        health = Hp;
    }

    public void SetHp(float Hp)
    {
        health = Hp;
    }

    public void Off()
    {
        HpTop.SetActive(false);
    }
}
