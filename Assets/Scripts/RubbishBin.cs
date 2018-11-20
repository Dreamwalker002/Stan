using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class RubbishBin : MonoBehaviour, IPointerEnterHandler , IPointerExitHandler
{
    #region SINGLETON

    public static RubbishBin instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }else if (instance != this)
        {
            Destroy(this);
        }
    }

    #endregion

    public bool hovering;
    

    public void OnPointerEnter(PointerEventData eventData)
    {
        //do your stuff when highlighted
       // Debug.Log("Entering");
        hovering = true;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        hovering = false;
        //Debug.Log("Leaving");
    }
}

