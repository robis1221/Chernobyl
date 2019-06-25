using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class triggerRamp : MonoBehaviour
{

    public GameObject platform1;
    public GameObject platform2;
    public GameObject platform3;
    public GameObject platform4;

    void OnTriggerEnter(){
        platform1.GetComponent<MeshCollider>().enabled = true;
        platform2.GetComponent<MeshCollider>().enabled = true;
        platform3.GetComponent<MeshCollider>().enabled = true;
        platform4.GetComponent<MeshCollider>().enabled = true;
    }

}
