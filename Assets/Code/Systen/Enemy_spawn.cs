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

    // Update is called once per frame
    void Update()
    {
        if (Spawn)
        {
            StartCoroutine(spawn());
        }
        

    }

    IEnumerator spawn()
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
        yield return new WaitForSeconds(5);
        Instantiate(CharacterMalee, spawnP.position, spawnP.rotation);
        yield return new WaitForSeconds(5);
        Instantiate(CharacterMalee, spawnP.position, spawnP.rotation);
        yield return new WaitForSeconds(4);
        Instantiate(CharacterMalee, spawnP.position, spawnP.rotation);
        yield return new WaitForSeconds(6);
        Instantiate(CharacterTank, spawnP.position, spawnP.rotation);
        Spawn = true;
    }
}
