using System.Collections.Generic;
using UnityEngine;

public interface IGenerator
{
    int numberOfInstances
    {
        get;
        set;
    }

    float radius
    {
        get;
        set;
    }

    GameObject cylinder
    {
        get;
        set;
    }

    Bounds cylinderBounds
    {
        get;
        set;
    }

    GameObject baseObject
    {
        get;
        set;
    }

    List<GameObject> listOfInstances
    {
        get;
        set;
    }
    void InitializeGameObjects();
    IGenerator GetInstance();
}
