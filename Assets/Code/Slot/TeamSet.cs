using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Team", menuName = "TeamSysten/Create Team")]
public class TeamSet : ScriptableObject
{
    public List<TeamSetSlot> Team = new List<TeamSetSlot>();
    public void addCharacter(GameObject _charac, Transform _Slot)
    {
        Team.Add(new TeamSetSlot(_charac,_Slot));
    }
    public void RemoveCharacter(GameObject _charac)
    {
        for (int i = 0; i < Team.Count; i++)
        {
            if (Team[i].charac == _charac)
            {
                Team.Remove(Team[i]);
            }            
        }
    }
    public Transform call(GameObject _charac)
    {
        Transform slot = _charac.GetComponent<Transform>();
        for (int i = 0; i < Team.Count; i++)
        {
            if (Team[i].charac == _charac)
            {
                slot = Team[i].Slot;
            }
        }
        return slot; 
    }
    public bool check(GameObject _charac)
    {
        bool have = false;
        for (int i = 0; i < Team.Count; i++)
        {
            if (Team[i].charac == _charac)
            {
                have = true;
            }
        }
        return have;
    }
}

[System.Serializable]
public class TeamSetSlot
{
    public GameObject charac;
    public Transform Slot;
    public TeamSetSlot(GameObject _charac, Transform _Slot)
    {
        charac = _charac;
        Slot = _Slot;
    }

}
