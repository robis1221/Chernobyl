using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class radiate : MonoBehaviour
{
    private bool active = false;
    private float lastTime = 0;
    private float currTime;
    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (active)
        {
            currTime += Time.deltaTime;
            if(currTime >= lastTime + 5)
            {
                player.GetComponent<Health>().health -= 1;
                lastTime = currTime;
            }
        }
    }

    public void setActive(bool data)
    {
        active = data;
    }
}
