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
    }
    #endregion

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

    private Vector3 location;

    //////////////////////////////////////////////////////////////////////////////////////////////////
   // public bool drag;

   // private float slowDown = .1f;
    //////////////////////////////////////////////////////////////////////////////////////////////////

    void LateUpdate()
    {

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

                float OrthoSize = UnityEngine.Camera.main.orthographicSize;
                OrthoSize += deltaDist;

                OrthoSize = Mathf.Clamp(OrthoSize, minMaxCamZoom.x, minMaxCamZoom.y);

                UnityEngine.Camera.main.orthographicSize = OrthoSize;

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


