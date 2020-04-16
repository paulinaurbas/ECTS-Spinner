using UnityEngine;

public class Gravity : MonoBehaviour
{

    private Quaternion rot;
    private Vector3 gravityValue;
    private Rigidbody rb;

    void Start()
    {
        gravityValue = Physics.gravity;
        //Physics.gravity.Set(0.0f, -9.81f, 0.0f);
        rb.useGravity = true;
        
    }

    void Update()
    {

    }
}
