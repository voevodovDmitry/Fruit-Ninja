using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{    
    
    [SerializeField] List<SpawnPoint>  spawnPoints;
    [SerializeField] GameObject prefabFruit;
    [SerializeField] List<Sprite> spritesFruit;


    [SerializeField] private float minDelay = 0.1f;
    [SerializeField] private float maxDelay = 0.3f;

    [SerializeField] private float maxSpeed = 17;
    [SerializeField] private float minSpeed = 14;

    [SerializeField] private int minQuantityFruits = 2;
    [SerializeField] private int maxQuantityFruits = 5;

    [SerializeField] private float delayBetweenWave = 7f;
    [SerializeField] private float stepBetweenWave = 0.2f;
    [SerializeField] private float minDelayBetweenWave = 0.5f;




    public int angle;
   

    void Start()    {
        StartCoroutine(SpawnFruits());
    }

    
    
    IEnumerator SpawnFruits()
    {
        while (true)
        {
            int quantityFruitsWave = Random.Range(minQuantityFruits, maxQuantityFruits);            
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
                prefabFruit.GetComponent<Fruit>().speedVector = ConfigSpeedVector(angle);
                prefabFruit.GetComponent<SpriteRenderer>().sprite = spritesFruit[Random.Range(0, spritesFruit.Count)];

                Instantiate(prefabFruit, spawnPoints[index].transform.position, spawnPoints[index].transform.rotation);

                delayBetweenWave -= stepBetweenWave;
                if (delayBetweenWave < minDelayBetweenWave)
                {
                    delayBetweenWave = minDelayBetweenWave;
                }

            }
           
        }
    }

    public int GetAngle(int index)
    {
        switch (index)
        {
            case 0:
                return spawnPoints[0].GetAngle();
            case 1:
                return spawnPoints[1].GetAngle();
            case 2:
                return spawnPoints[2].GetAngle();
            case 3:
                return spawnPoints[3].GetAngle();
            case 4:
                return spawnPoints[4].GetAngle();
            default:
                break;
        }
        return 0;
    }

    private int GetRandomPriorityIndex()
    {
        int sumPriority = 0;
        List<int> priorityList = new List<int>();

        foreach (SpawnPoint spawnPoint in spawnPoints)
        {
            sumPriority += spawnPoint.priority;
            priorityList.AddRange(spawnPoint.GetLocalPriorityList());
        }
        
        int randomPriorityIndex = priorityList[Random.Range(0, priorityList.Count)];
        

        return randomPriorityIndex;
    }

    private Vector3 ConfigSpeedVector(int angle)
    {
        float speed = Random.Range(minSpeed, maxSpeed);
        float componentX = speed * Mathf.Cos(angle * Mathf.PI / 180);
        float componentY = speed * Mathf.Sin(angle * Mathf.PI / 180);
        Vector3 speedVector = new Vector3(componentX, componentY, 0);
        return speedVector;
    }

}
