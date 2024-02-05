using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Spawn_Rocket : MonoBehaviour
{
    public Team Thisteam;
    public TMP_Text TMP_Text;
    public int Cost = 50;
    public Slider CoolDown;
    [SerializeField] Button button;
    public float CcUpRock = 60;

    public GameObject Rockget;
    public Transform FireStart_point1;
    public Transform Start_point;
    public Transform centermap_point;
    public static Transform End_point;   
    public static float distan;


    private void Awake()
    {
        CoolDown.maxValue = CcUpRock;
        CoolDown.value = CoolDown.maxValue;
        TMP_Text.text = "Rockget" + "\n" + "Cost : " + Cost;
    }
    // Start is called before the first frame update
    void Start()
    {
        End_point = FireStart_point1;
        distan = Vector2.Distance(FireStart_point1.position, centermap_point.position);
    }

    // Update is called once per frame
    void Update()
    {
        ButtomOnOFf();
    }

    public void fire()
    {
        CoolDown.maxValue = 60;
        CoolDown.value = CoolDown.maxValue;
        StartCoroutine(FireRockket());
        Sound.playSound();
    }

    IEnumerator FireRockket()
    {
        for (int i = 0; i < 20; i++)
        {
            yield return new WaitForSeconds(0.2f);
            Instantiate(Rockget, End_point.transform.position, Quaternion.identity);
        }     

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
    private void OnDrawGizmos()
    {
        Gizmos.DrawWireCube(Start_point.position, new Vector2(25, 4));
    }
}
