using UnityEngine;

public class HoesRayCastForRealBro : MonoBehaviour
{
    public float dmg;
    public float range = 100f;
    public Camera cam;
    GameObject fireHit;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Fire1")){
            RaycastHit hit;
            if(Physics.Raycast(cam.transform.position, cam.transform.forward, out hit, range)){
                Debug.Log(hit.collider.name);
            }
        }
    }
}
