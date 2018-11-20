using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class PanButton : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public Camera cameraHere;
    public Vector3 storedPos;
    public Vector3 currentPos;
    public Vector3 perviousPos;
    public Transform stuntExit;
    public Vector3 sceneOffSet;
    public bool panbuttonUp = false;
    public float panSpeed;
    public bool panbuttonDown;

    private Vector3 location;

    public UnityEvent onLongClick;

    void Awake()
    {
        storedPos = cameraHere.transform.position;
    }
    void Update()
    {
        perviousPos = cameraHere.transform.position;
        if (panbuttonDown == true)
        {
            ToExit();

            if (onLongClick != null)
                onLongClick.Invoke();
        }
        if (panbuttonUp == true)
        {
            BackToPoint();
        }
    }
    public void OnPointerDown(PointerEventData eventData)
    {
        currentPos = cameraHere.transform.position;
        panbuttonDown = true;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        panbuttonUp = true;
        panbuttonDown = false;
        panSpeed = 2;
        StartCoroutine(PanbuttonUpOff());
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



