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
    //private bool Demo = true;
    private float dif = 0;

    // Update is called once per frame
    void Update()
    {
        dif += Time.deltaTime;
        //if (Demo)
        //{
        //    StartCoroutine(tutorial());
        //}
        if (Spawn)
        {
            if (dif<120)
            {
                StartCoroutine(spawnST1());
            }
            else if (dif > 120 )
            {
                StartCoroutine(spawnST2());
            }
            else if (dif > 300 )
            {
                StartCoroutine(spawnST3());
            }

            
        }


    }
    IEnumerator tutorial()
    {
        for (int i = 0; i < 5; i++)
        {
            yield return new WaitForSeconds(8);
            Instantiate(CharacterMalee, spawnP.position, spawnP.rotation);
        }
        //Demo = false;
    }

    IEnumerator spawnST1()
    {
        Spawn = false;
        yield return new WaitForSeconds(5);
        Instantiate(CharacterMalee, spawnP.position, spawnP.rotation);
        yield return new WaitForSeconds(5);
        Instantiate(CharacterMalee, spawnP.position, spawnP.rotation);
        yield return new WaitForSeconds(5);
        Instantiate(CharacterMalee, spawnP.position, spawnP.rotation);
        yield return new WaitForSeconds(6);
        Instantiate(CharacterMalee, spawnP.position, spawnP.rotation);
        yield return new WaitForSeconds(7);
        Spawn = true;
    }

    IEnumerator spawnST2()
    {
        Spawn = false;
        yield return new WaitForSeconds(3);
        Instantiate(CharacterMalee, spawnP.position, spawnP.rotation);
        yield return new WaitForSeconds(5);
        Instantiate(CharacterMalee, spawnP.position, spawnP.rotation);
        yield return new WaitForSeconds(5);
        Instantiate(CharacterTank, spawnP.position, spawnP.rotation);
        yield return new WaitForSeconds(6);
        Instantiate(CharacterRang, spawnP.position, spawnP.rotation);
        yield return new WaitForSeconds(3);
        Instantiate(CharacterMalee, spawnP.position, spawnP.rotation);
        yield return new WaitForSeconds(5);
        Instantiate(CharacterMalee, spawnP.position, spawnP.rotation);
        yield return new WaitForSeconds(4);
        Instantiate(CharacterMalee, spawnP.position, spawnP.rotation);
        yield return new WaitForSeconds(6);
        Instantiate(CharacterTank, spawnP.position, spawnP.rotation);
        yield return new WaitForSeconds(5);
        Spawn = true;

    }

    IEnumerator spawnST3()
    {
        Spawn = false;
        yield return new WaitForSeconds(3);
        Instantiate(CharacterMalee, spawnP.position, spawnP.rotation);
        yield return new WaitForSeconds(5);
        Instantiate(CharacterMalee, spawnP.position, spawnP.rotation);
        yield return new WaitForSeconds(5);
        Instantiate(CharacterMalee, spawnP.position, spawnP.rotation);
        yield return new WaitForSeconds(6);
        Instantiate(CharacterRang, spawnP.position, spawnP.rotation);
        yield return new WaitForSeconds(3);
        Instantiate(CharacterMalee, spawnP.position, spawnP.rotation);
        yield return new WaitForSeconds(5);
        Instantiate(CharacterMalee, spawnP.position, spawnP.rotation);
        yield return new WaitForSeconds(4);
        Instantiate(CharacterMalee, spawnP.position, spawnP.rotation);
        yield return new WaitForSeconds(4);
        Instantiate(CharacterMalee, spawnP.position, spawnP.rotation);
        yield return new WaitForSeconds(3);
        Spawn = true;


    }
}
