using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    
    [SerializeField] GameObject fruitPrefab;
    [SerializeField] List<SpawnPoint>  spawnPoints;
    

    private float minDelay = 0.1f;
    private float maxDelay = 0.3f;

    private float maxSpeed = 17;
    private float minSpeed = 14;

    private int minQuantityFruits = 2;
    private int maxQuantityFruits = 5;

    private float delayBetweenWave = 7f;
    private float stepBetweenWave = 0.2f;
    private float minDalayBetweenWave = 0.5f;




    public int angle;
    public Vector3 speedVector;

    void Start()    {

        StartCoroutine(SpawnFruits());
    }

    
    void Update()
    {
       
    }

    IEnumerator SpawnFruits()
    {
        while (true)
        {
            int quantityFruitsWave = Random.Range(minQuantityFruits, maxQuantityFruits);
            Debug.Log(quantityFruitsWave);
            float delay = Random.Range(minDelay, maxDelay);
            for (int i = 0; i < quantityFruitsWave; i++)
            {
                if (i == quantityFruitsWave - 1)
                {
                    delay += delayBetweenWave;
                }

                yield return new WaitForSeconds(delay);

                int index = GetRandomPriorityIndex();
                angle = GetAngle(index);
                speedVector = ConfigSpeedVector(angle);
                fruitPrefab.GetComponent<Fruit>().speedVector = speedVector;
                Instantiate(fruitPrefab, spawnPoints[index].transform.position, spawnPoints[index].transform.rotation);
                delayBetweenWave -= stepBetweenWave;
                if (delayBetweenWave < minDalayBetweenWave)
                {
                    delayBetweenWave = minDalayBetweenWave;
                }

            }
           
        }
    }

    public int GetAngle(int index)
    {
        switch (index)
        {
            case 0:
                return Random.Range(spawnPoints[0].minAngle, spawnPoints[0].maxAngle);
            case 1:
                return Random.Range(spawnPoints[1].minAngle, spawnPoints[1].maxAngle);
            case 2:
                return Random.Range(spawnPoints[2].minAngle, spawnPoints[2].maxAngle);
            case 3:
                return Random.Range(spawnPoints[3].minAngle, spawnPoints[3].maxAngle);
            case 4:
                return Random.Range(spawnPoints[4].minAngle, spawnPoints[4].maxAngle);
            default:
                break;
        }
        return 0;
    }

    private int GetRandomPriorityIndex()
    {
        int randomPriorityIndex = 0;
        int sumPriority = spawnPoints[0].priority + spawnPoints[1].priority + spawnPoints[2].priority + spawnPoints[3].priority + spawnPoints[4].priority;
        List<int> priorityList = new List<int>();

        for (int i = 0; i < spawnPoints[0].priority; i++)
        {
            priorityList.Add(0);
        }

        for (int i = 0; i < spawnPoints[1].priority; i++)
        {
            priorityList.Add(1);
        }

        for (int i = 0; i < spawnPoints[2].priority; i++)
        {
            priorityList.Add(2);
        }

        for (int i = 0; i < spawnPoints[2].priority; i++)
        {
            priorityList.Add(3);
        }

        for (int i = 0; i < spawnPoints[3].priority; i++)
        {
            priorityList.Add(4);
        }

        randomPriorityIndex = priorityList[Random.Range(0, priorityList.Count)];
       

        return randomPriorityIndex;
    }

    private Vector3 ConfigSpeedVector(int angle)
    {
        float speed = Random.Range(minSpeed, maxSpeed);
        float componentX = speed * Mathf.Cos(angle * Mathf.PI / 180);
        float componentY = speed * Mathf.Sin(angle * Mathf.PI / 180);
        speedVector = new Vector3(componentX, componentY, 0);
        return speedVector;
    }

}
