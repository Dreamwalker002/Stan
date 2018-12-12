using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CameraMovement : MonoBehaviour
{
    //////////////////////////////////////////////////////////////////////////////////////////////////
    //pointer over UI
    private bool IsPointerOverUIObject()
    {
        PointerEventData eventDataCurrentPosition = new PointerEventData(EventSystem.current);
        eventDataCurrentPosition.position = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        List<RaycastResult> results = new List<RaycastResult>();
        EventSystem.current.RaycastAll(eventDataCurrentPosition, results);
        return results.Count > 0;
    }

    #region singlton

    public static CameraMovement instance;

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(gameObject);

        storedPos = transform.position;
        
    }
    #endregion

    ///////// LevelOverView /////////////////////////////////////////////////////////////////////////////////////////

    public Vector2 storedPos;
    public Vector2 moveToPos;
    public AnimationCurve animatedMoveCurve;

    public float startingSize;
    public float endingSize = 10;
    Camera mainCamera;

    private void Start()
    {
        mainCamera = GetComponent<Camera>();
        startingSize = mainCamera.orthographicSize;
        ToExit();
    }

    public void ToExit()
    {
        smoothSpeed = 2f;
        StartCoroutine(PanbuttonUpOff());
    }

    IEnumerator PanbuttonUpOff()
    {
        yield return new WaitForSeconds(1f);

        yield return StartCoroutine(LerpWithTime(transform, storedPos, moveToPos, 6f, startingSize, endingSize));

        yield return new WaitForSeconds(2f);

        yield return StartCoroutine(LerpWithTime(transform, moveToPos, storedPos, 8f, endingSize, startingSize));

    }

    IEnumerator LerpWithTime(Transform objectToMove, Vector3 a, Vector3 b, float speed, float startOrtho, float finishOrtho)
    {
        float step = (speed / (a - b).magnitude) * Time.deltaTime;
        float t = 0;
        while (t <= 1.0f)
        {
            t += step; // Goes from 0 to 1, incrementing by step each time
            objectToMove.position = Vector3.Lerp(a, b, animatedMoveCurve.Evaluate(t)); // Move objectToMove closer to b

            mainCamera.orthographicSize = Mathf.Lerp(startOrtho, finishOrtho, animatedMoveCurve.Evaluate(t));
            yield return new WaitForFixedUpdate();         // Leave the routine and return here in the next frame
        }
        objectToMove.position = b;
        mainCamera.orthographicSize = finishOrtho;
    }
    //////////////////////////////////////////////////////////////////////////////////////////////////

    public Transform target;

    public float smoothSpeed;

    public float dragMultiplier = 0.01f;

    public Vector3 offSet;

    public PlayerManager playerManager;

    public float camDrag = 1f;

    public Vector3 cameraVelocity;

    [Header("Clamp Values")]
    public float minX;
    public float maxX;
    public float minY;
    public float maxY;

    float prevDistance;

    public Vector2 minMaxCamZoom;
    float orthoSize;

    private Vector3 location;

    //////////////////////////////////////////////////////////////////////////////////////////////////
    // public bool drag;

    // private float slowDown = .1f;
    //////////////////////////////////////////////////////////////////////////////////////////////////


    void LateUpdate()
    {
        //ToExit();

        if (playerManager.stanInPlay == false)
        {
            smoothSpeed = 2f;

            if (Input.GetMouseButton(2)) // Middle mouce on computer to drag
            {
                smoothSpeed = 6f;
                cameraVelocity += (new Vector3(-Input.GetAxis("Mouse X"), -Input.GetAxis("Mouse Y"), 0) * dragMultiplier);
            }
            //if not dragging and if not stan in play and if over a ui element
            if ((Input.touchCount == 1) && (!IsPointerOverUIObject()) && (Drag.globalDragging == false))
            {

                //move the camera
                smoothSpeed = 10f;
                Vector2 averageDelta = new Vector2();

                averageDelta = averageDelta + Input.GetTouch(0).deltaPosition;
                averageDelta = averageDelta / smoothSpeed;

                cameraVelocity += new Vector3(-averageDelta.x, -averageDelta.y, 0) * dragMultiplier;
            }

            else if (Input.touchCount > 1)
            {
                //Check that our two fingers distance is less then x
                //Zoom the camera
                if (prevDistance == 0)
                {
                    prevDistance = Vector2.Distance(Input.GetTouch(0).position, Input.GetTouch(1).position);
                }
                //Debug.Break();
                float dist = Vector2.Distance(Input.GetTouch(0).position, Input.GetTouch(1).position);
                float deltaDist = (prevDistance - dist);
                prevDistance = dist;

                deltaDist = deltaDist / 10;

                mainCamera.orthographicSize = Mathf.Clamp(
                    mainCamera.orthographicSize += deltaDist,
                    minMaxCamZoom.x, 
                    minMaxCamZoom.y);


                // Debug.Log(deltaDist);
                if (Input.GetTouch(1).phase == TouchPhase.Ended)
                {
                    prevDistance = 0;
                }
            }

        }

        //apply the drag
        cameraVelocity = cameraVelocity / camDrag * .95f;

        transform.position += cameraVelocity;

        //Clamp our positions
        Vector3 pos = transform.position;
        //Clamp the x
        pos.x = Mathf.Clamp(pos.x, minX, maxX);

        //Clamp the Y
        pos.y = Mathf.Clamp(pos.y, minY, maxY);

        transform.position = pos;

        if (playerManager.stanInPlay == true)
        {
            Vector3 desiredPosition = target.position + offSet;

            Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed * Time.deltaTime);
            transform.position = smoothedPosition;
        }

    }

}


