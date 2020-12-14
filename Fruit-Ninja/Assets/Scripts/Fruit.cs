using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fruit : MonoBehaviour
{
    SpawnManager spawnManager;
    
    Vector3 gravity = new Vector3(0, -10, 0);
    Vector3 speedVector;

    private float speedValue = 16;
    private float limitY = -90;
    private float limitX = 220;


    void Start()
    {

        spawnManager = GameObject.Find("Spawn Manager").GetComponent<SpawnManager>();

        speedVector = InitSpeed(spawnManager.angle);


    }

    
    void Update()
    {
        speedVector += gravity * Time.deltaTime;         
        transform.position += speedVector * Time.deltaTime;
        
        if (transform.position.y < limitY || transform.position.x > limitX || transform.position.x < -limitX )
        {
            Destroy(gameObject);
        }
    }

    Vector3 InitSpeed(int angle)
    {      
        float componentX = speedValue * Mathf.Cos(angle * Mathf.PI / 180);
        float componentY = speedValue * Mathf.Sin(angle * Mathf.PI / 180);       
        Vector3 speedVector = new Vector3(componentX, componentY, 0);       
        return speedVector;
    }
}
