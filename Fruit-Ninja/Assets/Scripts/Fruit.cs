using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fruit : MonoBehaviour
{
    [SerializeField] int angle;
    [SerializeField] float speedX = 10;
    [SerializeField] float speedY = 10;
    [SerializeField] float gravityValue = 10;

    Vector3 speed = new Vector3(10, 10, 0);
    Vector3 gravity = new Vector3(0, -10, 0);


    

    void Start()
    {
        InitSpeed();
    }

    
    void Update()
    {
        speed += gravity * Time.deltaTime;         
        transform.position += speed * Time.deltaTime;
    }

    void InitSpeed()
    {

        float myltipliyX = Mathf.Cos(angle * Mathf.PI / 180);
        float myltipliyY = Mathf.Sin(angle * Mathf.PI / 180);
        speed.x = speed.x * myltipliyX;
        speed.y = speed.y * myltipliyY;       
    }
}
