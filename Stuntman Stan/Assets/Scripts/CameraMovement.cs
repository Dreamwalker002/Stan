using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{

    public Transform target;

    public float smoothSpeed;

    public float dragMultiplier = 0.01f;

    public Vector3 offSet;

    public PlayerManager playerManager;

    public float drag = 1;

    public Vector3 cameraVelocity;



    [Header("Clamp Values")]
    public float minX;
    public float maxX;
    public float minY;
    public float maxY;

    float prevDistance;


    //////////////////////////////////////////////////////////////////////////////////////////////////
    /*
    public Vector3 storedPos;
    public Vector3 currentPos;
    public Vector3 perviousPos;
    public Transform stuntExit;
    public Vector3 sceneOffSet;// offSet;
    public bool ingaged = false;
    public float panSpeed;//smoothSpeed
    public bool buttonDown;


    //////////////////////////////////////////////////////////////////////////////////////////////////

    private Vector3 location;
    
    //////////////////////////////////////////////////////////////////////////////////////////////////
    void Awake()
    {
        storedPos = transform.position;
    }*/
    void LateUpdate()
    {
        // gameManager.panbutton = buttonDown;

        if (playerManager.stanInPlay == false)
        {
            smoothSpeed = 2f;

            if (Input.GetMouseButton(2))
            {
                smoothSpeed = 20f;
                cameraVelocity += (new Vector3(-Input.GetAxis("Mouse X"), -Input.GetAxis("Mouse Y"), 0) * dragMultiplier);
            }
            if (Input.touchCount > 1)
            {
                //Check that our two fingers distance is less then x
                //Debug.Log(Vector2.Distance(Input.GetTouch(0).position, Input.GetTouch(1).position));

                if (Vector2.Distance(Input.GetTouch(0).position, Input.GetTouch(1).position) < 90)
                {

                    smoothSpeed = 20f;
                    Vector2 averageDelta = new Vector2();

                    averageDelta = averageDelta + Input.GetTouch(0).deltaPosition + Input.GetTouch(1).deltaPosition;
                    averageDelta = averageDelta / 2;

                    cameraVelocity += (new Vector3(-averageDelta.x, -averageDelta.y, 0) * dragMultiplier);
                }
                else
                {
                    if (prevDistance == 0)
                    {
                        prevDistance = Vector2.Distance(Input.GetTouch(0).position, Input.GetTouch(1).position);
                    }
                    float dist = Vector2.Distance(Input.GetTouch(0).position, Input.GetTouch(1).position);
                    float deltaDist = (prevDistance - dist);
                    prevDistance = dist;

                    deltaDist = deltaDist / 10;

                    float OrthoSize = UnityEngine.Camera.main.orthographicSize;
                    OrthoSize += deltaDist;

                    OrthoSize = Mathf.Clamp(OrthoSize, 5, 50);

                    UnityEngine.Camera.main.orthographicSize = OrthoSize;

                    // Debug.Log(deltaDist);
                }
                if (Input.GetTouch(1).phase == TouchPhase.Ended)
                {
                    // Debug.Log("Cancel move/zoom");
                    prevDistance = 0;
                }
            }
        }

        //apply the drag
        cameraVelocity = cameraVelocity / drag;

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



        ////////////////////////////////////////////////////////////////////////////////////////////////////////
        /*
        perviousPos = transform.position;

        if ((ingaged == false) && (buttonDown == true))
        {
            BackToPoint();

            if (perviousPos == storedPos)

            {
                currentPos = perviousPos;
            }

        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////////
        location = UnityEngine.Camera.main.ScreenToWorldPoint(Input.mousePosition);
        PanButton();
        ToExit();
        */
    }
    ////////////////////////////////////////////////////////////////////////////////////////////////////////

  /*  void ToExit()
    {

        if (Input.GetMouseButton(0))// && (buttonDown == true)))
        {
            ingaged = true;

            storedPos = currentPos;

            Vector3 desiredPosition = stuntExit.position;

            Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, panSpeed * Time.deltaTime);
            transform.position = smoothedPosition;
        }

        if (Input.GetMouseButtonUp(0))
        {
            ingaged = false;
            buttonDown = false;
        }

    }

    public void BackToPoint()

    {
        Vector3 desiredPosition = storedPos;

        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, panSpeed * Time.deltaTime);

        transform.position = smoothedPosition;
    }

    public void PanButton()
    //   { if (location)
    {
        buttonDown = true;
    }

    */
}


