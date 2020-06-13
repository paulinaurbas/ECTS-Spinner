using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class YourScore : MonoBehaviour
{
    public int ECTSPoints;
    public Text ECTSPointsText;
    // Start is called before the first frame update
    void Start()
    {
        ECTSPointsText.text = "POINTS: " + ECTSPoints.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
