using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Accelometer : MonoBehaviour
{
    // Start is called before the first frame update
    private Rigidbody rigidbody;
    public bool isFlat = true;
    private void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    private void Update()
    {
        Vector3 tilt = Input.acceleration;

        if (isFlat)
            tilt = Quaternion.Euler(90, 0, 0) * tilt;


        rigidbody.AddForce(Input.acceleration);
        Debug.DrawRay(transform.position +Vector3.up, tilt, Color.cyan);
    }
}
