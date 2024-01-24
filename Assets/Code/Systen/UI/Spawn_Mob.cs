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
    private static Queue<GameObject> Q = new Queue<GameObject>();
    private static bool QuOpen = true;


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
        SpawnQS();
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
        if (Cost<Player_core.Money)
        {
            CoolDown.value = CoolDown.maxValue;
            Spawn_Mob.Q.Enqueue(Character);
            //Instantiate(Character, spawnP.position, spawnP.rotation);
            Player_core.MinusMoney(Cost);        
        }
       
    }

    public void SpawnQS()
    {
        if (Spawn_Mob.Q.Count == 0)
        {
            return;
        }
        StartCoroutine(SpawnQ());

    }

    IEnumerator SpawnQ()
    {       
        if (!Check_LimitP.Limit&& Spawn_Mob.QuOpen)
        {
            Spawn_Mob.QuOpen = false;         
            Instantiate(Spawn_Mob.Q.Dequeue(), spawnP.transform.position, spawnP.rotation);
            yield return new WaitForSeconds(0.2f);
            Spawn_Mob.QuOpen = true;

        }

    }
}
