using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.EventSystems;



public class CreateItem : MonoBehaviour
{


    public GameObject[] stunItems;
    private Vector3 location;
    public Drag drag;


    void StunItems(int i)

    {
        GameObject itemObject = Instantiate(stunItems[i], (location), transform.rotation);
        drag = itemObject.GetComponent<Drag>();
        drag.dragging = true;
    }


    /// //////////////////////////////////////////////////////////////////////////////////////////

    public void ItemOne()
    {
        location = UnityEngine.Camera.main.ScreenToWorldPoint(Input.mousePosition);
        StunItems(0);

    }

    public void ItemTwo()
    {
        location = UnityEngine.Camera.main.ScreenToWorldPoint(Input.mousePosition);
        StunItems(1);

    }

    public void ItemThree()
    {
        location = UnityEngine.Camera.main.ScreenToWorldPoint(Input.mousePosition);
        StunItems(2);

    }

    public void ItemFour()
    {
        location = UnityEngine.Camera.main.ScreenToWorldPoint(Input.mousePosition);
        StunItems(3);

    }

}
