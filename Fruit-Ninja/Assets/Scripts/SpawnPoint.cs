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

}
