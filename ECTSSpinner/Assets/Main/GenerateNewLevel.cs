using System;
using System.Collections.Generic;
using UnityEngine;


public class GenerateNewLevel
{
    private GenerateECTSs _ects = GenerateECTSs.Instance;
    private GenerateObstacles _obstacles = GenerateObstacles.Instance;
    private Destroyer _destroyer = new Destroyer();
    public static int levelNumber = 4;

    public void DestroyAllGameObjects() //I AM THE CATACLYSM
    {
        _destroyer.DestroyObjects(_ects.listOfInstances);
        _destroyer.DestroyObjects(_obstacles.listOfInstances);
    }

    public void ChangeMainObstacleModel()
    {
        levelNumber++;

        switch(levelNumber)
        {
            case 1:
                SpawnObstacles.baseObstacle = GameObject.Find("Hamburger");
                break;
            case 2: 
                SpawnObstacles.baseObstacle = GameObject.Find("Book"); //KNIGI
                break;
            case 3: 
                SpawnObstacles.baseObstacle = GameObject.Find("DMUX");
                break;
            case 4:
                SpawnObstacles.baseObstacle = GameObject.Find("Penguin"); //Komputer
                break;
            case 5:
                SpawnObstacles.baseObstacle = GameObject.Find("Csharp"); //<3
                break;
            case 6:
                SpawnObstacles.baseObstacle = GameObject.Find("Resistor"); //Resistor
                break;
            case 7:
                SpawnObstacles.baseObstacle = GameObject.Find("Computer"); //Komputer
                break;
            case 8:
                SpawnObstacles.baseObstacle = GameObject.Find("Apple"); //iOS
                break;
            case 9:
                SpawnObstacles.baseObstacle = GameObject.Find("Android"); //Andrut
                break;
        }
    }
    public void GenerateNextLevel() //I bring life, and hope
    {

        _obstacles.numberOfInstances += 25;
        ChangeMainObstacleModel();
        _obstacles.InitializeGameObjects();

        _ects.InitializeGameObjects();   
    }

    public void MovePlayerToStart()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        player.transform.position = new Vector3(-0.02f, 7.761f, -107.12f);
    }
}
