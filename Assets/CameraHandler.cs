using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Vehicles.Car;
public class CameraHandler : MonoBehaviour
{
    public GameObject personControl;
    public GameObject car;
    public Camera carCam;
    //public GameObject thirdPersCar;
    public bool carActive = false;
    private bool personActive = true;
    
    // Start is called before the first frame update
    void Start()
    {
        personControl.SetActive(personActive);
        car.GetComponent<CarController>().enabled = carActive;
        car.GetComponent<CarUserControl>().enabled = carActive;
        carCam.enabled = carActive;
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(car.GetComponent<CarController>().CurrentSpeed);
        if(Input.GetKeyUp("c") && carActive == false && Vector3.Distance(personControl.transform.position, car.transform.position) < 5)
        {
            carActive = true;
            personActive = false;
            car.GetComponent<CarController>().enabled = carActive;
            car.GetComponent<CarUserControl>().enabled = carActive;
            carCam.enabled = carActive;
            personControl.SetActive(personActive);
            
            return;
        }
        else if(Input.GetKeyUp("c") && carActive == true && car.GetComponent<CarController>().CurrentSpeed <= 2)
        {
            carActive = false;
            personActive = true;
            personControl.transform.position = car.transform.position;
            personControl.transform.rotation = car.transform.rotation;
  
            Vector3 personPosX = personControl.transform.position;
            personPosX += Vector3.left * 3;
            personControl.transform.position = personPosX;

            car.GetComponent<CarController>().enabled = carActive;
            car.GetComponent<CarUserControl>().enabled = carActive;
            carCam.enabled = carActive;

            personControl.SetActive(personActive);
            return;
        }
    }
}
