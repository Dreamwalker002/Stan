using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CameraMovement : MonoBehaviour
{
    //////////////////////////////////////////////////////////////////////////////////////////////////

   
    //////////////////////////////////////////////////////////////////////////////////////////////////

    public Transform target;

    public float smoothSpeed;

    public float dragMultiplier = 0.01f;

    public Vector3 offSet;

    public PlayerManager playerManager;

    public float camDrag = 1;

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

    void LateUpdate()
    {
       


        if (playerManager.stanInPlay == false)
        {
            smoothSpeed = 2f;//change back to 2 for phone

            if (Input.GetMouseButton(2))
            {
                smoothSpeed = 20f;
                cameraVelocity += (new Vector3(-Input.GetAxis("Mouse X"), -Input.GetAxis("Mouse Y"), 0) * dragMultiplier);
            }
            //if not dragging and if not stan in play and if over a ui element
            if ((Input.touchCount == 1) && (EventSystem.current.IsPointerOverGameObject() == false))
            {
                //move the camera
                smoothSpeed = 2f;
                Vector2 averageDelta = new Vector2();
                 Debug.Log("smoothSpeed"+ smoothSpeed);

                averageDelta = averageDelta + Input.GetTouch(0).deltaPosition;
                //averageDelta = averageDelta / 2;

                cameraVelocity += (new Vector3(-averageDelta.x, -averageDelta.y, 0) * dragMultiplier);
            }
            else if (Input.touchCount > 1)
            {
                //Check that our two fingers distance is less then x
                //Debug.Log(Vector2.Distance(Input.GetTouch(0).position, Input.GetTouch(1).position));
                //Zoom the camera
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

                OrthoSize = Mathf.Clamp(OrthoSize, minMaxCamZoom.x, minMaxCamZoom.y);

                UnityEngine.Camera.main.orthographicSize = OrthoSize;

                // Debug.Log(deltaDist);
                if (Input.GetTouch(1).phase == TouchPhase.Ended)
                {
                    // Debug.Log("Cancel move/zoom");
                    prevDistance = 0;
                }
            }

            Debug.Log("smoothSpeed2" + smoothSpeed);
        }
        Debug.Log("smoothSpeed3" + smoothSpeed);
        //apply the drag
        cameraVelocity = cameraVelocity / camDrag;

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


