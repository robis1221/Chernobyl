using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trigger : MonoBehaviour
{
    public fireSpawner script;
    public GameObject radiationHandler;
    public GameObject nikolay;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(){
        nikolay.GetComponent<NikolayScript>().state = 2;
        script.isTrigger = true;
        radiationHandler.GetComponent<radiate>().setActive(true);
    }
}
