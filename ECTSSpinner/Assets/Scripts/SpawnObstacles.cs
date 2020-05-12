using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnObstacles : MonoBehaviour
{
    private GameObject _cylinder;
    private Bounds _cylinderBounds;
    private float _radius;
    public List<GameObject> objectsList = new List<GameObject>(); //TO DO?

    public int amountOfObstacles = 1;
    public GameObject cube;
    // Start is called before the first frame update
    void Start()
    {
        _cylinder = GameObject.FindGameObjectWithTag("cylinderMain");
        _cylinderBounds = _cylinder.GetComponent<MeshCollider>().bounds;
        _radius = (_cylinderBounds.max.x - _cylinderBounds.min.x) / 2;

        initializeGameObjects();
    }

    private void initializeGameObjects()
    {
        for (int i = 0; i < amountOfObstacles; i++)
        {
            bool obstacleIntersects = false;

            float angle = UnityEngine.Random.Range(0, 360);
            float posZ = UnityEngine.Random.Range(_cylinderBounds.min.z, _cylinderBounds.max.z);
            float posX = _radius * (float)Math.Cos(angle);
            float posY = _radius * (float)Math.Sin(angle);
            float size = UnityEngine.Random.Range(1, 5);

            var newObstacle = Instantiate(cube, new Vector3(posX, posY, posZ), Quaternion.AngleAxis(angle, new Vector3(0, 0, 1)));
            newObstacle.transform.localScale = new Vector3(size, size, size);
            newObstacle.name ="obstacleCube_" + i.ToString();

            do //Prevent cubes from spawning inside eachother
            {
                foreach (GameObject item in objectsList)
                {
                    if (item.GetComponent<BoxCollider>().bounds.Intersects(newObstacle.GetComponent<BoxCollider>().bounds))
                    {
                        angle = UnityEngine.Random.Range(0, 360);
                        posZ = UnityEngine.Random.Range(_cylinderBounds.min.z, _cylinderBounds.max.z);
                        posX = _radius * (float)Math.Cos(angle);
                        posY = _radius * (float)Math.Sin(angle);

                        newObstacle.transform.position = new Vector3(posX, posY, posZ);
                        obstacleIntersects = true;
                    }
                }
                   
            } while (obstacleIntersects);

            objectsList.Add(newObstacle);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
