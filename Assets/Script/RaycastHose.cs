using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaycastHose : MonoBehaviour
{
    public int hoseDamage = 10;
    public float hoseRange = 50f;
    public Transform hoseEnd;
    public GameObject camObject;

    private AudioSource HoseAudio;
    private Camera fpsCam;

    private LineRenderer laserLine;
    private float nextFire;

    public float soundCliplenght;
    // Start is called before the first frame update
    void Start()
    {
        laserLine = GetComponent<LineRenderer>();
        HoseAudio = GetComponent<AudioSource>();
        fpsCam = camObject.GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButton("Fire1"))
        {
            if(HoseAudio.isPlaying == false){
                HoseAudio.Play();
            }

            Vector3 rayOrigin = fpsCam.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, 0.0f));
            RaycastHit hit;

            laserLine.SetPosition(0, hoseEnd.position);

            if (Physics.Raycast(rayOrigin, fpsCam.transform.forward, out hit, hoseRange))
            {
                laserLine.SetPosition(1, hit.point);
                FireHealth health = hit.collider.GetComponent<FireHealth>();

                if (health != null)
                {
                    health.Damage(hoseDamage);
                }
            }
            else
            {
                laserLine.SetPosition(1, rayOrigin + (fpsCam.transform.forward * hoseRange));

            }
        }
        else
        {
            HoseAudio.Stop();
            laserLine.enabled = false;
        }

    }
    private IEnumerator HoseEffect()
    {
        HoseAudio.Play();
        laserLine.enabled = true;
        yield return new WaitForSeconds(5.0f);


    }
}
