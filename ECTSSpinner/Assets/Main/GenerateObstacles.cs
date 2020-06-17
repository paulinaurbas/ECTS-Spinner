using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class GenerateObstacles : IGenerator
{
    private static readonly GenerateObstacles _instance = new GenerateObstacles();
    public GameObject cylinder { get; set; }
    public Bounds cylinderBounds { get; set; }
    public float radius { get; set; }
    public List<GameObject> listOfInstances { get; set; }
    public int numberOfInstances { get; set; }
    public GameObject baseObject { get; set; }
    public Destroyer destroyer { get; set; }
    private GenerateObstacles()
    {
        listOfInstances = new List<GameObject>();
    }
    public IGenerator GetInstance()
    {
        return Instance;
    }

    public static GenerateObstacles Instance
    {
        get { return _instance; }
    }

    private Vector3 AdjustScale()
    {
        Vector3 adjustedScale = new Vector3(1,1,1);

        switch (GenerateNewLevel.levelNumber)
        {
            case 0: //UMBRELLA
                adjustedScale = new Vector3(0.01777778f * 16, 0.008888894f * 16, 0.0003f * 16);
                break;
            case 1: //BURGER
                adjustedScale = new Vector3(1.555556f * 14, 1.555556f * 14, 0.03f * 14);
                break;
            case 2: //BOOK
                adjustedScale = new Vector3(0.2844445f, 0.05f, 0.0058f);
                break;
            case 3: //DMUX
                adjustedScale = new Vector3(0.01777778f * 8, 0.008888894f * 8, 0.0003f * 8);
                break;
            case 4: //PENGUIN
                adjustedScale = new Vector3(0.01777778f * 4, 0.008888894f * 4, 0.0003f * 4);
                break;
            case 5: //C#
                adjustedScale = new Vector3(35.554f * 10, 27.777788f * 10, 6f * 3);
                break;
            case 6: //RESISTOR
                adjustedScale = new Vector3(0.01777778f * 60, 0.008888894f * 60, 0.0003f * 60);
                break;
            case 7: //COMPUTER
                adjustedScale = new Vector3(0.01777778f * 20, 0.008888894f * 20, 0.0003f * 20);
                break;
            case 8: //APPLE
                adjustedScale = new Vector3(0.3555556f * 100, 0.377779f * 100, 0.006f * 100);
                break;
            case 9: //ANDROID
                adjustedScale = new Vector3(0.3555556f * 120, 0.377779f * 120, 0.006f * 120);
                break;
        }

        return adjustedScale;
    }

    public void InitializeGameObjects()
    {
        baseObject = SpawnObstacles.baseObstacle;

        cylinderBounds = cylinder.GetComponent<MeshCollider>().bounds;
        radius = 7.5f; //Tested radius - for some f-up reason it grew
        GameObject player = GameObject.FindGameObjectWithTag("Player");

        for (int i = 0; i < numberOfInstances; i++)
        {
            bool obstacleIntersects = false;

            float angle = UnityEngine.Random.Range(0, 360);
            float posZ = UnityEngine.Random.Range(cylinderBounds.min.z, cylinderBounds.max.z);
            float posX = radius * (float)Math.Cos(angle);
            float posY = radius * (float)Math.Sin(angle);

            var newObstacle = GameObject.Instantiate(baseObject, new Vector3(0, 0, 0), Quaternion.identity);

            newObstacle.transform.RotateAround(new Vector3(0, 0, 1), angle - 90);
            newObstacle.transform.position = new Vector3(posX, posY, posZ);
            newObstacle.transform.parent = cylinder.transform;

            newObstacle.transform.localScale = AdjustScale(); 
            
            
            newObstacle.name = "obstacle_" + i.ToString();

            //Prevent cubes from spawning inside eachother
            if (player.GetComponent<CapsuleCollider>().bounds.Intersects(newObstacle.GetComponent<BoxCollider>().bounds))
            {
                newObstacle.SetActive(false);
                obstacleIntersects = true;
            }

            if(obstacleIntersects == false)
                listOfInstances.Add(newObstacle);
        }
    }
}