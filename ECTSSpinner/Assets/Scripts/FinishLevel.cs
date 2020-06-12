using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishLevel : MonoBehaviour
{
    private readonly GenerateNewLevel _newLevel = new GenerateNewLevel();
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Ball")
        {
            // TODO: Transfer the scene to some MENU without the ball 
            //       and the accelerometr script. It collapses in this 
            //       version due to the fact that it tries to change 
            //       position of the ball even if it is destroyed
            //Destroy(collision.gameObject);
            _newLevel.DestroyAllGameObjects();
            _newLevel.MovePlayerToStart();
            //Goto next-level-screen/summary
            _newLevel.GenerateNextLevel();    
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
