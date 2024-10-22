﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CollectECTSPoint : MonoBehaviour
{

    public static int ECTSPoints;
    public Text ECTSPointsText;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("ECTS"))
        {
            collision.gameObject.SetActive(false);
            // TODO: Add fireworks effects 
            ECTSPoints++;
            ECTSPointsText.text = "ECTS: " + ECTSPoints.ToString();
            Debug.Log("ECTSPoints = " + ECTSPoints);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
