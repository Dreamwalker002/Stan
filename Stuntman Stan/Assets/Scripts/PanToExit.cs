using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PanToExit : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public Camera cameraHere;
    public Vector3 storedPos;
    public Vector3 currentPos;
    public Vector3 perviousPos;
    public Transform stuntExit;
    public Vector3 sceneOffSet;
    public bool ingaged = false;
    public float panSpeed;
    public bool panbuttonDown;
    public bool panbuttonUp = true;
    private Vector3 location;

    void Awake()
    {
        storedPos = cameraHere.transform.position;
    }

    void LateUpdate()
    {
        perviousPos = cameraHere.transform.position;

        if ((ingaged == true) && (panbuttonDown == false))
        {

           if (panbuttonUp == true)
            {
                BackToPoint();
            }
        }

        ToExit();
    }

    void ToExit()
    {

        if ((Input.GetMouseButton(0) && (panbuttonDown == true)))
        {
            panSpeed = 2;

            ingaged = true;

            panbuttonUp = false;

            storedPos = currentPos;

            Vector3 desiredPosition = stuntExit.position;

            Vector3 smoothedPosition = Vector3.Lerp(cameraHere.transform.position, desiredPosition, panSpeed * Time.deltaTime);
            cameraHere.transform.position = smoothedPosition;
        }

        if (Input.GetMouseButtonUp(0))
        {

            StartCoroutine(IngagedOff());
            panbuttonDown = false;
            panbuttonUp = true;
        }

    }

    public void BackToPoint()

    {
        Vector3 desiredPosition = storedPos;

        Vector3 smoothedPosition = Vector3.Lerp(cameraHere.transform.position, desiredPosition, panSpeed * Time.deltaTime);

        cameraHere.transform.position = smoothedPosition;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        currentPos = cameraHere.transform.position;
        
        panbuttonDown = true;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        panbuttonUp = true;
        panbuttonDown = false;
        StartCoroutine(IngagedOff());
    }

    IEnumerator IngagedOff()
    {
        panSpeed = 8;
         yield return new WaitForSeconds(1.5f);
        ingaged = false;
        currentPos = perviousPos;
    }

}


