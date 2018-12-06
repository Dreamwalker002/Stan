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

    public float floatSnap = .5f;


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

            //Vector3 floatSnap = new Vector3(5f, 5f , 0);

            //Snap to int grid
           // worldPosition = new Vector3(Mathf.Round(worldPosition.x)/100f * 100, Mathf.Round(worldPosition.y)/100f*100);
           // worldPosition = new Vector3(Mathf.Round(worldPosition.x / floatSnap.x),Mathf.Round(worldPosition.y / floatSnap.y));

            //int intSnap;
            
            //floatSnap = Mathf.Round(intSnap)/2;

            transform.position = Snap.snap(worldPosition, .5f) ;

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


[System.Serializable]
public class Snap
{

    public static Vector3 snap(Vector3 pos, float v)
    {
        float x = pos.x;
        float y = pos.y;
        float z = pos.z;
        x = Mathf.Round(x / v) * v;
        y = Mathf.Round(y / v) * v;
        z = Mathf.Round(z / v) * v;
        return new Vector3(x, y, z);
    }

} 
