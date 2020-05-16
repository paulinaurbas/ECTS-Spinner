using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnObstacles : MonoBehaviour
{
    private GenerateObstacles _generator = GenerateObstacles.Instance;
    public GameObject baseObstacle;
    public int numberOfObstacles;
    // Start is called before the first frame update
    void Start()
    {

        _generator.cylinder = GameObject.FindGameObjectWithTag("cylinderMain");
        _generator.baseObject = baseObstacle;
        _generator.numberOfInstances = numberOfObstacles;

        _generator.InitializeGameObjects();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
