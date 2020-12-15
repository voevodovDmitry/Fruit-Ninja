using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPoint : MonoBehaviour
{
    public int minAngle;
    public int maxAngle;
    public int priority;
    static public int angle;

    public int GetAngle()
    {
        return Random.Range(this.minAngle, this.maxAngle);
    }

    public List<int> GetLocalPriorityList()
    {
        List<int> localPriorityList = new List<int>();

        for (int i = 0; i < priority; i++)
        {
            localPriorityList.Add(priority);
        }
        
        return localPriorityList;
    }

}
