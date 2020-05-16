using System;
using System.Collections.Generic;
using UnityEngine;


public class GenerateNewLevel
{
    private GenerateECTSs _ects = GenerateECTSs.Instance;
    private GenerateObstacles _obstacles = GenerateObstacles.Instance;
    private Destroyer _destroyer = new Destroyer();

    public void DestroyAllGameObjects() //I AM THE CATACLYSM
    {
        _destroyer.DestroyObjects(_ects.listOfInstances);
        _destroyer.DestroyObjects(_obstacles.listOfInstances);
    }

    public void GenerateNextLevel() //I bring life, and hope
    {
        _obstacles.numberOfInstances += 25;
        _obstacles.InitializeGameObjects();

        _ects.InitializeGameObjects();   
    }

    public void MovePlayerToStart()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        player.transform.position = new Vector3(-0.02f, 7.761f, -107.12f);
    }
}
