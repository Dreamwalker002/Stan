using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class FanDrag : MonoBehaviour
{
    public CameraMovement cameraMovementScript;

    public Drag dragScript;

    public GameObject fan;

    public bool dragging;

    public float snapDist = 2;

    public void OnMouseDown()
    {
        if (EventSystem.current.IsPointerOverGameObject() == false)
        {
            dragging = true;
        }
    }

    private void Update()
    {

        if (dragScript.playermanagerScript.stanInPlay == false)
        {
            if (dragging)
            {


                Vector3 currentPosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0);

                Vector3 worldPosition = UnityEngine.Camera.main.ScreenToWorldPoint(currentPosition);

                //Snap to int grid
               // worldPosition = new Vector3((int)worldPosition.x, (int)worldPosition.y);

                //Clamp our position
                //releative to our x position from our fan
                float relativeX = fan.transform.position.x - worldPosition.x;
                relativeX = Mathf.Abs(relativeX);

                worldPosition.y = Mathf.Clamp(worldPosition.y, fan.transform.position.y + relativeX, 100000);
                worldPosition.z = 0;

                transform.position = Snap.snap(worldPosition, .5f);

                if (Input.GetMouseButtonUp(0))
                {
                    dragging = false;
                    //reset our position to x dist from fan
                    Vector3 offset = transform.position - fan.transform.position;
                    offset = offset.normalized * snapDist;
                    transform.position = fan.transform.position + offset;
                    Vector3 pos = transform.position;
                    pos.z = 0;
                    transform.position = pos;

                }
                Drag.globalDragging = dragging;
            }
        }
    }
}