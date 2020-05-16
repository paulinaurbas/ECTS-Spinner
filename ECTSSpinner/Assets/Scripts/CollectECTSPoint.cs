using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CollectECTSPoint : MonoBehaviour
{

    public int ECTSPoints;
    public Text ECTSPointsText;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("ECTS"))
        {
            Destroy(collision.gameObject);
            // TODO: Add fireworks effects 
            ECTSPoints++;
            ECTSPointsText.text = "POINTS: " + ECTSPoints.ToString();
            Debug.Log("ECTSPoints = " + ECTSPoints);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
