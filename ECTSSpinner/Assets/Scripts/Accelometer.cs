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
    private GameObject _background;

    void Start()
    {
        _cylinder = GameObject.FindGameObjectWithTag("cylinderMain");
        ballSpeed = ballSpeed / 100;
        rb = GetComponent<Rigidbody>();
        _background = GameObject.FindGameObjectWithTag("Background");

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
        _background.transform.position = new Vector3(0, 0, rb.position.z + 400);
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

