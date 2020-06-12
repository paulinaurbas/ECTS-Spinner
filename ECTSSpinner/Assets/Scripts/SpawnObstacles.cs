using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnObstacles : MonoBehaviour
{
    private GenerateObstacles _generator = GenerateObstacles.Instance;
    public static GameObject baseObstacle;
    public int numberOfObstacles;
    // Start is called before the first frame update
    void Start()
    {
        if (baseObstacle == null)
            baseObstacle = GameObject.Find("Umbrella");

        _generator.cylinder = GameObject.FindGameObjectWithTag("cylinderMain");

        _generator.numberOfInstances = numberOfObstacles;

        _generator.InitializeGameObjects();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
