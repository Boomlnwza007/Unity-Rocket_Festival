using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Spawn_Mob : MonoBehaviour
{
    public int Cost = 5;
    public Slider CoolDown;
    [SerializeField] Button button;
    public GameObject Character;
    public Transform spawnP;
    public TMP_Text text;

    private void Awake()
    {
        CoolDown.maxValue = Character.GetComponent<E1>().CcSpawn;
        CoolDown.value = CoolDown.maxValue;
        Cost = Character.GetComponent<E1>().Cost;
        text.text = Character.name + "\n" +"Cost : "+ Character.GetComponent<E1>().Cost;
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

    public void Spawn()
    {
        Debug.Log(Cost+"  >  "+Player_core.Money);
        if (Cost<Player_core.Money)
        {
            CoolDown.value = CoolDown.maxValue;
            Instantiate(Character, spawnP.position, spawnP.rotation);
            Player_core.MinusMoney(Cost);        
        }
       
    }
}
