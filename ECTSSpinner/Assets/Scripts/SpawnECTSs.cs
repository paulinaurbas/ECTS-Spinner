using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnECTSs : MonoBehaviour
{
    private GenerateECTSs _generator = GenerateECTSs.Instance;
    public GameObject baseECTS;
    // Start is called before the first frame update
    void Start()
    {
        _generator.cylinder = GameObject.FindGameObjectWithTag("cylinderMain");
        _generator.baseObject = baseECTS;

        _generator.InitializeGameObjects();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
