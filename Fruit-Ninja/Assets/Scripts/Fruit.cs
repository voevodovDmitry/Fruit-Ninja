using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fruit : MonoBehaviour
{
    
    
    
    Vector3 gravity = new Vector3(0, -10, 0);
    public Vector3 speedVector;
    
    private float limitY = -90;
    private float limitX = 220;


    void Start()
    {


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

    
}
