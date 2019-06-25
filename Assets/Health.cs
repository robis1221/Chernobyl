using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Health : MonoBehaviour
{
    public float health;
    public CanvasGroup canvas;
    private float time = 10;
    private float lastTime = 0;
    bool dead;
    public GameObject liveCamera;
    public GameObject deathCamera;
    public GameObject nikolay;
   
    // Start is called before the first frame update
    void Start()
    {
        dead = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (health <= 20 && health > 0)
        {
            time += Time.deltaTime;
            if (time >= lastTime + health / 2)
            {
                Fade();
                lastTime = time;
            }
        }

        if (health <= 0 && dead == false)
        {
            Debug.Log("You DEAD!!!!");
            deathCamera.transform.position = liveCamera.transform.position;
            deathCamera.transform.rotation = liveCamera.transform.rotation;
            liveCamera.SetActive(false);
            deathCamera.SetActive(true);
            deathCamera.GetComponent<rotate>().setRotate(true);
            nikolay.GetComponent<NikolayScript>().state = 3;
            deathFade();
            dead = true;
           
        }

        if (health <= 0 && dead == true)
        {
            endScreen();
        }



    }

    void Fade()
    {
        StartCoroutine(Fading());
    }

    void deathFade()
    {
        StartCoroutine(deathFading());
    }
   
    void endScreen()
    {
        StartCoroutine(nextScreen());
    }

    IEnumerator Fading()
    {
        while(canvas.alpha < 1)
        {
            canvas.alpha += Time.deltaTime / 2;
            yield return null;
        }

        while(canvas.alpha > 0)
        {
            canvas.alpha -= Time.deltaTime / 2;
            yield return null;
        }

        yield return null;
    }

    IEnumerator deathFading()
    {
        while (canvas.alpha < 1)
        {
            canvas.alpha += Time.deltaTime / 2;
          
            yield return null;
           
        }
        
       
        yield return null;
      
    }

    IEnumerator nextScreen()
    {
        
            yield return new WaitForSeconds(10);
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
       
    }
}
