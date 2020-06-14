using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CollectedECTS : MonoBehaviour
{

    CollectECTSPoint CollectECTSPoint;
    public Text ectsCollectedText; 

    // Start is called before the first frame update
    void Start()
    {
        ectsCollectedText.text = CollectECTSPoint.ECTSPoints.ToString();
        CollectECTSPoint.ECTSPoints = 0; 
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
