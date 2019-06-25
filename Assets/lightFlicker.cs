using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lightFlicker : MonoBehaviour
{
    Light lt;
    public float minNoise;
    public float maxNoise;
    // Start is called before the first frame update
    void Start()
    {
        lt = GetComponent<Light>();
        lt.type = LightType.Point;
    }

    // Update is called once per frame
    void Update()
    {
        lt.intensity = Random.Range(minNoise, maxNoise);
    }
}
