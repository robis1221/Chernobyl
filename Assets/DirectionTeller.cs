using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DirectionTeller : MonoBehaviour
{
    public int direction;
    public GameObject nikolay;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (direction == 0)
        {
            nikolay.GetComponent<NikolayScript>().needsToGoLeft = true;
        }
        else if(direction == 1){
            nikolay.GetComponent<NikolayScript>().needsToGoRight = true;
        }
        else if (direction == 2)
        {
            nikolay.GetComponent<NikolayScript>().wrongWay = true;
        }
        Destroy(this);
    }

}
