using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(CharacterController))]
public class Accelometer : MonoBehaviour
{
 
    private Rigidbody rb;
    public float ballSpeed = 0;
    private float forwardSpeed = 20.0f;
    private GameObject _cylinder;
    void Start()
    {
        _cylinder = GameObject.FindGameObjectWithTag("cylinderMain");
        ballSpeed = ballSpeed / 100;
        rb = GetComponent<Rigidbody>();

    }
    void AccelometrMove()
    {
        float x = Input.acceleration.x;
        Debug.Log("X = " + x);

        if (x < -0.1f)
        {
            MoveLeft();
        }
        else if (x > 0.1f)
        {
            MoveRight();
        }
        else
        {
            SetVelocityZero();
        }
    }

    private void SetVelocityZero()
    {
        rb.velocity = new Vector3(0, 0, forwardSpeed);
    }

    private void MoveRight()
    {
          rb.velocity = new Vector3(0,0, forwardSpeed);
        _cylinder.transform.RotateAround(new Vector3(0, 0, 1), ballSpeed);
    }

    private void MoveLeft()
    {
        rb.velocity = new Vector3(0, 0, forwardSpeed);
        _cylinder.transform.RotateAround(new Vector3(0, 0, 1), -ballSpeed);
    }

    void Update()
    {
        AccelometrMove();
     
        
    }


}

