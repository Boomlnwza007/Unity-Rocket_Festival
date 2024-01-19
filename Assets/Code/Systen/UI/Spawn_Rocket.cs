using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Spawn_Rocket : MonoBehaviour
{
    public TMP_Text TMP_Text;
    public int Cost = 50;
    public Slider CoolDown;
    [SerializeField] Button button;
    public float CcUpRock = 60;

    private GameObject Rockget;
    public static Transform Start_point;
    public Transform End_point;
    public Vector2 dir_point;
    public static Transform[] Target;
    public static int ID = 0;
    public Team Thisteam;
    private float distan;
    // Start is called before the first frame update
    void Start()
    {
        float X = Mathf.Abs(Start_point.position.x - End_point.position.x);
        X /= 2;
        dir_point = Start_point.position - End_point.position;
        dir_point = dir_point.normalized;
        distan = X;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void fire()
    {
        ID = 0;
        RaycastHit2D[] tar = Physics2D.RaycastAll(Start_point.position, dir_point, distan);
        foreach (var item in tar)
        {
            if (item.collider.tag == "Unit")
            {
                if (Thisteam != item.collider.GetComponent<ITeam>().CTeam())
                {
                    Target[ID] = item.transform;
                    Instantiate(Rockget, Start_point);
                    ID++;
                }
            }
        }
    }
}
