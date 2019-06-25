using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthManager : MonoBehaviour
{
    public int startHealth = 100;
    public int currentHealth;
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = startHealth;
    }

    // Update is called once per frame
    void Update()
    {
      if(Input.GetMouseButtonDown(0))
      {
          TakeDamage(1);
      }
    }
    public void TakeDamage(int amount)
    {
        currentHealth -= amount;
        if(currentHealth < 20)
        Destroy(this);
        transform.localScale -= new Vector3(0.2f, 0.2f, 0.2f);
    }
}
