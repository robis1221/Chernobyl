using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotate : MonoBehaviour
{
    bool rot = false;
    public float rotationSpeed;
    Quaternion temp;
    // Start is called before the first frame update
    void Start()
    {
        temp = transform.rotation;
    }

    // Update is called once per frame
    void Update()
    {
        if (rot)
        {
            Quaternion from = transform.rotation;
            Quaternion to = temp * Quaternion.Euler(0, 0, -90);
            transform.rotation = Quaternion.Slerp(from, to, rotationSpeed * Time.deltaTime);
        }
    }

    public void setRotate(bool data)
    {
        rot = data;
    }
}
