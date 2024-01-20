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
    private static Queue<GameObject> Q;

    private void Awake()
    {
        if (Character.GetComponent<E1>())
        {
            CoolDown.maxValue = Character.GetComponent<E1>().CcSpawn;
            Cost = Character.GetComponent<E1>().Cost;
            text.text = ""+Character.GetComponent<E1>().Cost;
        }
        if (Character.GetComponent<R1>())
        {
            CoolDown.maxValue = Character.GetComponent<R1>().CcSpawn;
            Cost = Character.GetComponent<R1>().Cost;

            text.text = ""+ Character.GetComponent<R1>().Cost;
        }
        
        
        CoolDown.value = CoolDown.maxValue;
        
        
        
    }

    private void Update()
    {
        ButtomOnOFf();
        SpawnQ();
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
            //Q.Enqueue(Character);
            Instantiate(Character, spawnP.position, spawnP.rotation);
            Player_core.MinusMoney(Cost);        
        }
       
    }

    public void SpawnQ()
    {
        if (Q == null)
        {
            return;
        }
        if (!Check_LimitP.Limit)
        {
            Instantiate(Q.Peek(), spawnP.position, spawnP.rotation);
        }
    }
}
