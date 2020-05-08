using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishLevel : MonoBehaviour
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
            // TODO: Do not destroy the ball, move it to the start position
            //       Regenerate the level, change colors and things like that
            //       OR just change the scene!
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
