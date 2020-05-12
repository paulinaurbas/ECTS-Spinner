using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnECTSs : MonoBehaviour
{
    public SpawnObstacles obstacles;

    private GameObject _cylinder;
    private Bounds _cylinderBounds;
    private float _radius;

    private int _amountOfECTS;
    private float _range;
    public GameObject ECTS;
    // Start is called before the first frame update
    void Start()
    {
        _amountOfECTS = obstacles.amountOfObstacles / 10;

        _cylinder = GameObject.FindGameObjectWithTag("cylinderMain");
        _cylinderBounds = _cylinder.GetComponent<MeshCollider>().bounds;
        _radius = (_cylinderBounds.max.x - _cylinderBounds.min.x) / 2;

        _range = (_cylinderBounds.max.z - _cylinderBounds.min.z - 20) / _amountOfECTS;

        InitializeGameObjects();
    }

    private void InitializeGameObjects()
    {
        for (int i = 0; i < _amountOfECTS; i++)
        {
            bool ECTSIntersects = false;

            float angle = UnityEngine.Random.Range(0, 360);
            float posZ = _range * i + _cylinderBounds.min.z + 10;
            float posX = _radius * (float)Math.Cos(angle);
            float posY = _radius * (float)Math.Sin(angle);

            var newECTS = Instantiate(ECTS, new Vector3(posX, posY, posZ), Quaternion.AngleAxis(angle, new Vector3(0, 0, 1)));
            newECTS.name = "ECTSPoint_" + i.ToString();
            newECTS.tag = "ECTS";

            do //Prevent ECTS from spawning inside the Obstacles
            {
                foreach (GameObject item in obstacles.objectsList)
                {
                    if (item.GetComponent<BoxCollider>().bounds.Intersects(newECTS.GetComponent<CapsuleCollider>().bounds))
                    {
                        angle = UnityEngine.Random.Range(0, 360);
                        posZ += 2;
                        posX = _radius * (float)Math.Cos(angle);
                        posY = _radius * (float)Math.Sin(angle);

                        newECTS.transform.position = new Vector3(posX, posY, posZ);
                        ECTSIntersects = true;
                    }
                }

            } while (ECTSIntersects);
        }
    }
}
