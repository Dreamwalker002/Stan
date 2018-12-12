using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelOverView : MonoBehaviour {



    public Camera cameraHere;
    public Vector3 storedPos;
    public Vector3 currentPos;
    public Vector3 perviousPos;
    public Transform stuntExit;
    public bool panbuttonUp = false;
    public float panSpeed;


    private Vector3 location;


    void Awake()
    {
        storedPos = cameraHere.transform.position;
    }
    void Update()
    {
        perviousPos = cameraHere.transform.position;
       
    }
 
    void LevelLayout()
    {
 ToExit();
        StartCoroutine(PanbuttonUpOff());
        BackToPoint();
    }
 
    
    public void ToExit()
    {
        panSpeed = 1;
        storedPos = currentPos;

        Vector3 desiredPosition = stuntExit.position;
        Vector3 smoothedPosition = Vector3.Lerp(cameraHere.transform.position, desiredPosition, panSpeed * Time.deltaTime);
        cameraHere.transform.position = smoothedPosition;
    }
    public void BackToPoint()
    {
        Vector3 desiredPosition = storedPos;
        Vector3 smoothedPosition = Vector3.Lerp(cameraHere.transform.position, desiredPosition, panSpeed * Time.deltaTime);
        cameraHere.transform.position = smoothedPosition;
    }
    IEnumerator PanbuttonUpOff()
    {
        yield return new WaitForSeconds(2.5f);
        panbuttonUp = false;
        currentPos = perviousPos;
    }

}



