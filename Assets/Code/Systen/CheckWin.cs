using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckWin : MonoBehaviour
{
    public Tower TUnit;
    public Tower TEnermy;
    public GameObject Win;
    public GameObject Lose;
    // Start is called before the first frame update

    // Update is called once per frame
    void Update()
    {
        if (TEnermy.Hp<=0)
        {
            Time.timeScale = 0;
            Win.SetActive(true);
        }
        if (TUnit.Hp <= 0)
        {
            Time.timeScale = 0;
            Lose.SetActive(true);
        }
    }
}
