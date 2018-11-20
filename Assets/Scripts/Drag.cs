using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Drag : MonoBehaviour
{
    Vector3 distance;
    private float posX;
    private float posY;

    public PlayerManager playermanagerScript;


    public bool dragging;

    public float rotationSpeed;//rotate around point

    private bool handle;//rotate around point

    public ItemCost itemScript;

    public GameObject pivotPoint;


    private void Awake()
    {
        playermanagerScript = PlayerManager.instance;
    }


    public void OnMouseDown()
    {
        if ((EventSystem.current.IsPointerOverGameObject() == false) && (playermanagerScript.stanInPlay == false))
        {
            dragging = true;
        }
    }


    private void OnTriggerEnter(Collider rotatorHandle)//rotate around point
    {
        if (rotatorHandle.gameObject.tag == "Pivot")
        {
            handle = true;
            //   Debug.Log("handle");
        }
    }

    private void Update()
    {





        if (dragging)
        {
            Vector3 currentPosition = new Vector3(Input.mousePosition.x - posX, Input.mousePosition.y - posY, 0);

            Vector3 worldPosition = UnityEngine.Camera.main.ScreenToWorldPoint(currentPosition);

            //Snap to int grid
           // worldPosition = new Vector3((int)worldPosition.x, (int)worldPosition.y);

            transform.position = worldPosition;

            if (Input.GetMouseButtonUp(0))
            {
                dragging = false;


                if (RubbishBin.instance.hovering == true)
                {
                    //do stuff
                    itemScript = GetComponent<ItemCost>();

                    itemScript.Refund();

                    Destroy(gameObject);
                }

            }
        }

    }


}
