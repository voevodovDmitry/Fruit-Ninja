using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fruit : MonoBehaviour
{
    SpawnManager spawnM;

    Vector3 speed = new Vector3(20, 10, 0);
    Vector3 gravity = new Vector3(0, -10, 0);

    private float limitY = -9;
    private float limitX = 22;


    void Start()
    {
        
        spawnM = GameObject.Find("Spawn Manager").GetComponent<SpawnManager>();
        
        InitSpeed(spawnM.angle);


    }

    
    void Update()
    {
        speed += gravity * Time.deltaTime;         
        transform.position += speed * Time.deltaTime;

        if (transform.position.y < limitY || transform.position.x > limitX || transform.position.x < -limitX )
        {
            Destroy(gameObject);
        }
    }

    void InitSpeed(int angle)
    {
        float myltipliyX = Mathf.Cos(angle * Mathf.PI / 180);
        float myltipliyY = Mathf.Sin(angle * Mathf.PI / 180);
        speed.x = speed.x * myltipliyX;
        speed.y = speed.y * myltipliyY;       
    }
}
