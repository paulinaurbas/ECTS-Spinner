using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public class Destroyer //THE END OF ALL THINGS, INEVITABLE, INDOMITABLE; I AM THE CATACLYSM!
{
    public void DestroyObject(GameObject instance)
    {
        UnityEngine.Object.Destroy(instance);
    }

    public void DestroyObjects(List<GameObject> listOfInstances)
    {
        foreach (GameObject instance in listOfInstances)
            UnityEngine.Object.Destroy(instance);

        listOfInstances.Clear();
    }
}
