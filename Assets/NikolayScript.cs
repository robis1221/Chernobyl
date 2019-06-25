using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NikolayScript : MonoBehaviour
{
    public GameObject car;
    public int state;
    private Transform carTarget;
    private Vector3 carHeight =new Vector3 (0, 1, 0);
    private bool gotIntoCar=false;
    public AudioClip getIntoTheCarDima;
    public AudioClip dimaNotInCar;
    public AudioClip goRight;
    public AudioClip goLeft;
    public AudioClip wrongWayClip;
    private AudioSource audioSource;
    private float gotIntoCarTime;
    private bool s_dimaNotInCarBool=false;
    private bool s_getIntoTheCarDimaBool = false;
    private float gameStartTime;
    public bool wasDriving = false;
    public bool needsToGoRight = false;
    public bool needsToGoLeft = false;
    public bool wrongWay = false;
    public GameObject carRadio;
    public GameObject nikolaySong;
    private AudioSource carRadioSource;
    private AudioSource nikolayRadioSource;
    public GameObject EventHandle;
    private bool s_radio = false;
    private bool s_canPlayDirection = true;
    private bool s_ohshit = false;
    public AudioClip ohShitClip;
    private float state2Time;
    public AudioClip ohShitGoClip;
    public AudioClip dimaNoClip;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        carTarget = car.transform;
        gameStartTime = Time.time;
        carRadioSource = carRadio.GetComponent<AudioSource>();
        nikolayRadioSource = nikolaySong.GetComponent<AudioSource>();
    
    }

    // Update is called once per frame
    void Update()
    {
        //print(audioSource.isPlaying);
        wasDriving = EventHandle.GetComponent<CameraHandler>().carActive;
        if (Vector3.Distance(transform.position, carTarget.position) > 1f && gotIntoCar == false)
        {
            float step = 3f * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, carTarget.position + carHeight, step);
            gotIntoCarTime = Time.time;
        }
        else
        {
            gotIntoCar = true;
            transform.position = carTarget.position + carHeight;
            if (Time.time - gotIntoCarTime > 7 && s_dimaNotInCarBool == false && wasDriving == false&&state==0)
            {
                s_dimaNotInCarBool = true;
                audioSource.PlayOneShot(dimaNotInCar, 5f);
            }
        }
        if (state == 0)
        {
            if(Time.time - gameStartTime > 2 && s_getIntoTheCarDimaBool == false)
            {
                s_getIntoTheCarDimaBool = true;
                audioSource.PlayOneShot(getIntoTheCarDima, 5f);
            }
            if (wasDriving == true&&gotIntoCar==true)
            {
                state = 1;
            }
        }
        else if (state == 1)
        {
            if (wasDriving)
            {
                carRadioSource.mute = false;
            }
            if (s_radio == false)
            {
                nikolayRadioSource.Play();
                carRadioSource.Play();
                s_radio = true;
            }
            if (wasDriving == false)
            {
                nikolayRadioSource.mute = true;
                carRadioSource.mute = true;
            }
            else if (audioSource.isPlaying)
            {
                nikolayRadioSource.mute = true;
                s_canPlayDirection = false;
            }
            else
            {
                nikolayRadioSource.mute = false;
                s_canPlayDirection = true;
             
            }
            if (needsToGoRight == true&&s_canPlayDirection==true)
            {
                
                audioSource.PlayOneShot(goRight, 5f);
                needsToGoRight = false;
            }
            else if(needsToGoLeft == true&&s_canPlayDirection==true)
            {
                audioSource.PlayOneShot(goLeft, 5f);
                needsToGoLeft = false;
            }
            else if (wrongWay == true&&s_canPlayDirection==true)
            {
                audioSource.PlayOneShot(wrongWayClip, 5f);
                wrongWay = false;
            }
        }
        else if (state == 2)
        {
            if (s_ohshit == false)
            {
                nikolayRadioSource.mute = true;
                carRadioSource.mute = true;
                state2Time = Time.time;
                audioSource.PlayOneShot(ohShitClip,5f);
                s_ohshit = true;
            }
            else if (Time.time > state2Time + 25&& EventHandle.GetComponent<CameraHandler>().carActive)
                {
                audioSource.PlayOneShot(ohShitGoClip, 5f);
                state2Time = Time.time;
                }

        }
        else if (state == 3)
        {
            audioSource.PlayOneShot(dimaNoClip, 5f);
            state = 4;
        }
         
        }
    }
