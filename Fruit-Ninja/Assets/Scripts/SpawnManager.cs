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

            int index = Random.Range(0, spawnPoints.Count);
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
}
