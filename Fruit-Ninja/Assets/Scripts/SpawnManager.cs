using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] List<GameObject> spawnPoints;
    [SerializeField] GameObject fruitPrefab;

    private float minDelay = 1f;
    private float maxDelay = 3f;

    SpawnPoint spawnPoint_0;
    SpawnPoint spawnPoint_1;
    SpawnPoint spawnPoint_2;
    SpawnPoint spawnPoint_3;
    SpawnPoint spawnPoint_4;

    public int angle;

    void Start()
    {
        spawnPoint_0 = GameObject.Find("SpawnPointMidle").GetComponent<SpawnPoint>();
        spawnPoint_1 = GameObject.Find("SpawnPointRight").GetComponent<SpawnPoint>();
        spawnPoint_2 = GameObject.Find("SpawnPointLeft").GetComponent<SpawnPoint>();
        spawnPoint_3 = GameObject.Find("SpawnPointBotRight").GetComponent<SpawnPoint>();
        spawnPoint_4 = GameObject.Find("SpawnPointBotLeft").GetComponent<SpawnPoint>();

        StartCoroutine(SpawnFruits());
    }

    
    void Update()
    {
       
    }

    IEnumerator SpawnFruits()
    {
        while (true)
        {
            float delay = Random.Range(minDelay, maxDelay);
            yield return new WaitForSeconds(delay);

            int index = GetRandomPriorityIndex();
            angle = GetAngle(index);
            
            Instantiate(fruitPrefab, spawnPoints[index].transform.position, spawnPoints[index].transform.rotation);
        }
    }

    public int GetAngle(int index)
    {
        switch (index)
        {
            case 0:
                return Random.Range(spawnPoint_0.minAngle, spawnPoint_0.maxAngle);
            case 1:
                return Random.Range(spawnPoint_1.minAngle, spawnPoint_1.maxAngle);
            case 2:
                return Random.Range(spawnPoint_2.minAngle, spawnPoint_2.maxAngle);
            case 3:
                return Random.Range(spawnPoint_3.minAngle, spawnPoint_3.maxAngle);
            case 4:
                return Random.Range(spawnPoint_4.minAngle, spawnPoint_4.maxAngle);
            default:
                break;
        }
        return 0;
    }

    private int GetRandomPriorityIndex()
    {
        int randomPriorityIndex = 0;
        int sumPriority = spawnPoint_0.priority + spawnPoint_1.priority + spawnPoint_2.priority + spawnPoint_3.priority + spawnPoint_4.priority;
        List<int> priorityList = new List<int>();

        for (int i = 0; i < spawnPoint_0.priority; i++)
        {
            priorityList.Add(0);
        }

        for (int i = 0; i < spawnPoint_1.priority; i++)
        {
            priorityList.Add(1);
        }

        for (int i = 0; i < spawnPoint_2.priority; i++)
        {
            priorityList.Add(2);
        }

        for (int i = 0; i < spawnPoint_3.priority; i++)
        {
            priorityList.Add(3);
        }

        for (int i = 0; i < spawnPoint_4.priority; i++)
        {
            priorityList.Add(4);
        }

        randomPriorityIndex = priorityList[Random.Range(0, priorityList.Count)];
       

        return randomPriorityIndex;
    }
    
        
}
