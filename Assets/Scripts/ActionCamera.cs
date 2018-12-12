using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionCamera : MonoBehaviour
{

    public bool entered;
    //public GameObject camSnapShot;
    public Vector3 offSet;
    private Vector3 location;

    public GameObject camPrefab;

    GameObject spawnedCam;

    private void Awake()
    {

        location = transform.position + offSet;
    }


    private void OnTriggerEnter(Collider other)
    {
        /////////////// Particle ///////////////////////////////////////////////////////////////////////////////////
        // GameObject cameraFlash = Instantiate(camSnapShot, (location), transform.rotation);     
        // camSnapShot.transform.position = transform.position + offSet;
        //cameraFlash.GetComponent<ParticleSystem>(). Play();
        //////////////////////////////////////////////////////////////////////////////////////////////////

        spawnedCam = Instantiate(camPrefab);

        //Light lightComp = lightGameObject.AddComponent<Light>();

        spawnedCam.transform.position = location;

        entered = true;


    }

    private void OnTriggerExit(Collider other)
    {
        Destroy(spawnedCam);
    }


}


