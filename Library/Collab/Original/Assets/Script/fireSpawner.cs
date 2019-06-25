using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fireSpawner : MonoBehaviour
{

    public GameObject firePrefab;
    public int min = 1;
    public int max = 10;
    float spawnTime = 0;
    public float spawnInterval = 1f;
    int ddd = 0;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(spawner());
    }

    // Update is called once per frame
    void Update()
    {

    }

    void spawnFire(){
        GameObject fire = Instantiate(firePrefab);
        fire.transform.position = new Vector3(transform.position.x + Random.Range(min, max), transform.position.y, transform.position.z + Random.Range(min, max));
    }

    IEnumerator spawner()
    {
        while (true)
        {
        yield return new WaitForSeconds(spawnInterval);
        spawnFire();
        }
    }
}
