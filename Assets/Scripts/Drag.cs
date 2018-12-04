using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Drag : MonoBehaviour
{
    public static bool globalDragging;

    Vector3 distance;
    private float posX;
    private float posY;

    public PlayerManager playermanagerScript;

    public bool privateDragging;

    public float rotationSpeed;//rotate around point

    private bool handle;//rotate around point

    public ItemCost itemScript;

    public GameObject pivotPoint;


    private void Awake()
    {

        playermanagerScript = PlayerManager.instance;

        privateDragging = true;

    }

    public void OnMouseDown()
    {
        if ((EventSystem.current.IsPointerOverGameObject() == false) && (playermanagerScript.stanInPlay == false))
        {
            privateDragging = true;
        }
    }

    private void OnTriggerEnter(Collider rotatorHandle)//rotate around point
    {
        if (rotatorHandle.gameObject.tag == "Pivot")
        {
            handle = true;
            
        }
    }

    private void Update()
    {
        if (privateDragging)
        {
            
            Vector3 currentPosition = new Vector3(Input.mousePosition.x - posX, Input.mousePosition.y - posY, 0);

            Vector3 worldPosition = UnityEngine.Camera.main.ScreenToWorldPoint(currentPosition);

            //Snap to int grid
            // worldPosition = new Vector3((int)worldPosition.x, (int)worldPosition.y);

            transform.position = worldPosition;

            if (Input.GetMouseButtonUp(0))
            {
                privateDragging = false;
              
                if (RubbishBin.instance.hovering == true)
                {
                    //do stuff
                    itemScript = GetComponent<ItemCost>();

                    itemScript.Refund();

                    Destroy(gameObject);
                }

            }
            globalDragging = privateDragging;
        }

    }


}
