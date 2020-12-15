using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fruit : MonoBehaviour
{
    [SerializeField] private float rotatipnSpeed = 5f;
    private float randomRotationSpeed;
    [SerializeField] private float scaleValue = 0.005f;
    private float randomScaleValue;



    Vector3 gravity = new Vector3(0, -10, 0);
    public Vector3 speedVector;
    
    private float limitY = -90;
    private float limitX = 220;


    void Start()
    {

        randomRotationSpeed = Random.Range(-rotatipnSpeed, rotatipnSpeed);
        randomScaleValue = Random.Range(-scaleValue, scaleValue);
        
    }

    
    void Update()
    {
        speedVector += gravity * Time.deltaTime;         
        transform.position += speedVector * Time.deltaTime;
        
        if (transform.position.y < limitY || transform.position.x > limitX || transform.position.x < -limitX )
        {
            Destroy(gameObject);
        }

        

        transform.Rotate(0,0, randomRotationSpeed);
        transform.localScale += new Vector3(randomScaleValue, randomScaleValue, 0);
        
    }

    
}
