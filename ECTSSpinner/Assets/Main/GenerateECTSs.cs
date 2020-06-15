using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateECTSs : IGenerator
{
    private static readonly GenerateECTSs _instance = new GenerateECTSs();

    private GenerateObstacles _obstacles = GenerateObstacles.Instance;

    public GameObject cylinder { get; set; }
    public Bounds cylinderBounds { get; set; }
    public float radius { get; set; }
    public int numberOfInstances { get; set; }

    private float _range;
    public GameObject baseObject { get; set; }
    public List<GameObject> listOfInstances { get; set; }
    public Destroyer destroyer { get; set; }
    private GenerateECTSs()
    {
        listOfInstances = new List<GameObject>();
    }

    public static GenerateECTSs Instance
    {
        get { return _instance; }
    }

    public IGenerator GetInstance()
    {
        return Instance;
    }
    // Start is called before the first frame update

    private void RotateWithoutChildren(GameObject obj, Vector3 rotation, double angle)
    {
        List<Transform> listOfKids = new List<Transform>();

        foreach(Transform child in obj.transform)
        {
            child.transform.parent = null;
            listOfKids.Add(child);
        }

        obj.transform.Rotate(rotation, (float)angle);

        foreach (Transform child in listOfKids)
            child.transform.parent = obj.transform;
    }

    public void InitializeGameObjects()
    {
        numberOfInstances = _obstacles.numberOfInstances / 10;
        cylinderBounds = cylinder.GetComponent<MeshCollider>().bounds;

        radius = 7.55f;//(cylinderBounds.max.x - cylinderBounds.min.x) / 2;
        _range = (cylinderBounds.max.z - cylinderBounds.min.z - 20) / numberOfInstances;

        for (int i = 0; i < numberOfInstances; i++)
        {

            float angle = UnityEngine.Random.Range(0, 360);
            float posZ = _range * i + cylinderBounds.min.z + 10;
            float posX = radius * (float)Math.Cos(angle);
            float posY = radius * (float)Math.Sin(angle);

            var newECTS = GameObject.Instantiate(baseObject, new Vector3(0, 0, 2), Quaternion.identity);

            newECTS.transform.Rotate(new Vector3(0, 0, 1), angle - 90);

            newECTS.transform.position = new Vector3(posX, posY, posZ);
            newECTS.transform.parent = cylinder.transform;

            newECTS.transform.localScale = new Vector3(0.1f, 0.07f, 0.0015f);
            newECTS.name = "ECTSPoint_" + i.ToString();
            newECTS.tag = "ECTS";

            listOfInstances.Add(newECTS);

            //Prevent ECTS from spawning inside the Obstacles
            foreach (GameObject item in _obstacles.listOfInstances)
            {
                if (item.GetComponent<BoxCollider>().bounds.Intersects(newECTS.GetComponent<CapsuleCollider>().bounds))
                {
                    item.SetActive(false);
                    //_obstacles.listOfInstances.RemoveAt(_obstacles.listOfInstances.IndexOf(item));

                    //destroyer.DestroyObject(item);
                }
            }
        }
    }
}
