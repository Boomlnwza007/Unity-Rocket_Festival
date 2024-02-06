using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_spawn : MonoBehaviour
{
    public Transform spawnP;
    public GameObject CharacterMalee;
    public GameObject CharacterRang;
    public GameObject CharacterTank;
    public bool Spawn = true;
    public bool SpawnCC= true;
    private int spawnC = 0;
    private int spawnCMax = 0;
    //private bool Demo = true;
    [SerializeField]private float dif = 0;

    private void Start()
    {
        spawnCMax = Random.Range(2, 3);
    }

    // Update is called once per frame
    void Update()
    {
       bool v = Check_Limit.LimitE;
        dif += Time.deltaTime;
        if (spawnC >= spawnCMax)
        {
            SpawnCC = false;
            StartCoroutine(CoolDown(8));           
        }
        if (SpawnCC)
        {
            if (Spawn)
            {
                if (dif < 60)
                {
                    StartCoroutine(spawnST1());
                }
                else if (dif > 60)
                {
                    StartCoroutine(spawnST2());
                }
                else if (dif > 150)
                {
                    StartCoroutine(spawnST3());
                }
            }
        }     


    }
    IEnumerator tutorial()
    {
        for (int i = 0; i < 5; i++)
        {
            yield return new WaitForSeconds(8);
            Instantiate(CharacterMalee, spawnP.position, spawnP.rotation);
            spawnC++;
        }

    }

    IEnumerator spawnST1()
    {
        Spawn = false;
        float a = Random.Range(2, 4);       
        if (!Check_Limit.LimitE)
        {
            yield return new WaitForSeconds(a);
            Instantiate(CharacterMalee, spawnP.position, spawnP.rotation);
            spawnC++;
        }       
        Spawn = true;
    }

    IEnumerator spawnST2()
    {
        Spawn = false;
        float a = Random.Range(3, 4);
        int b = Random.Range(0, 100);
        if (b <= 55)
        {
            if (!Check_Limit.LimitE)
            {
                yield return new WaitForSeconds(a);
                Instantiate(CharacterMalee, spawnP.position, spawnP.rotation);
                spawnC++;
            }
        }
        else if (b <= 95)
        {
            a = Random.Range(4, 6);
            if (!Check_Limit.LimitE)
            {
                yield return new WaitForSeconds(a);
                Instantiate(CharacterRang, spawnP.position, spawnP.rotation);
                spawnC++;
            }
        }
        else
        {
            a = Random.Range(3, 5);
            if (!Check_Limit.LimitE)
            {
                yield return new WaitForSeconds(a);
                Instantiate(CharacterTank, spawnP.position, spawnP.rotation);
                spawnC++;
            }
        }
        Spawn = true;
    }

    IEnumerator spawnST3()
    {
        Spawn = false;
        float a = Random.Range(3, 4);
        int b = Random.Range(0, 100);
        if (b <= 55)
        {
            if (!Check_Limit.LimitE)
            {
                yield return new WaitForSeconds(a);
                Instantiate(CharacterMalee, spawnP.position, spawnP.rotation);
                spawnC++;
            }
        }
        else if (b <= 90)
        {
            a = Random.Range(3, 5);
            if (!Check_Limit.LimitE)
            {
                yield return new WaitForSeconds(a);
                Instantiate(CharacterRang, spawnP.position, spawnP.rotation);
                spawnC++;
            }
        }
        else
        {
            a = Random.Range(3, 5);
            if (!Check_Limit.LimitE)
            {
                yield return new WaitForSeconds(a);
                Instantiate(CharacterTank, spawnP.position, spawnP.rotation);
                spawnC++;
            }
        }
        Spawn = true;

    }

    IEnumerator CoolDown(float a)
    {
        yield return new WaitForSeconds(a);
        SpawnCC = true;
        spawnC = 0;
        spawnCMax = Random.Range(3, 5);
    }
}
