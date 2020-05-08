using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DieWhenCollide: MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Ball")
        {
            Destroy(collision.gameObject);
            // TODO: Add dying fireworks
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
