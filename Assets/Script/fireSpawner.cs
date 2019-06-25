using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fireSpawner : MonoBehaviour
{

    public GameObject firePrefab;
    public float spawnInterval = 1f;
    Vector3 prevpos;
    bool onece = true;
    public bool isTrigger = false;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(spawner());
    }

    // Update is called once per frame
    void Update()
    {
        if(isTrigger){
            Debug.Log("I am triggered!!");
        }

    }

    void spawnFire()
    {
        GameObject fire = Instantiate(firePrefab);
        int dir = Random.Range(1, 5);
        
        if(onece){
            prevpos = transform.position;
            onece = false;
        }
        switch (dir)
        {
            case 1:
                fire.transform.position = new Vector3(prevpos.x, transform.position.y+1.5f, prevpos.z + 1);
                break;

            case 2:
                fire.transform.position = new Vector3(prevpos.x + 1, transform.position.y+1.5f, prevpos.z);
                break;

            case 3:
                fire.transform.position = new Vector3(prevpos.x, transform.position.y+1.5f, prevpos.z - 1);
                break;

            case 4:
                fire.transform.position = new Vector3(prevpos.x - 1, transform.position.y+1.5f, prevpos.z);
                break;
        }
        prevpos = fire.transform.position;

    }

    IEnumerator spawner()
    {
        while (true)
        {
            yield return new WaitForSeconds(spawnInterval);
            if(isTrigger){
                spawnFire();
            }
        }
    }
}
