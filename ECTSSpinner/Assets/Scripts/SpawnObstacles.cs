using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnObstacles : MonoBehaviour
{
    private GameObject _cylinder;
    private Bounds _cylinderBounds;
    private float _radius;
    private List<GameObject> _objectsList; //TO DO?

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
            float angle = UnityEngine.Random.Range(0, 360);
            float posZ = UnityEngine.Random.Range(_cylinderBounds.min.z, _cylinderBounds.max.z);
            float posX = _radius * (float)Math.Cos(angle);
            float posY = _radius * (float)Math.Sin(angle);
            float size = UnityEngine.Random.Range(1, 5);

            cube.name = "obstacleCube_" + i.ToString();

            Instantiate(cube, new Vector3(posX, posY, posZ), Quaternion.AngleAxis(angle, new Vector3(0, 0, 1))).transform.localScale = new Vector3(size, size, size);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
