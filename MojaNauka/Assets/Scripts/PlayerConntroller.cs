using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerConntroller : MonoBehaviour
{
   
        private Rigidbody rb;
        private int ballSpeed = 10;
        private float forwardSpeed = 5.0f;

        void Start()
        {
            rb = GetComponent<Rigidbody>();
    
        }
        void AccelometrMove()
        {
            float x = Input.acceleration.x;
            Debug.Log("X = " + x);
            
            if(x < -0.1f)
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
        rb.velocity = Vector3.zero;
    }

    private void MoveRight()
    {
        rb.velocity = new Vector3(ballSpeed, 0, forwardSpeed); 
    }

    private void MoveLeft()
    {
        rb.velocity = new Vector3(-ballSpeed, 0, forwardSpeed);
    }

    void Update()
        {
        AccelometrMove();
    }


}

