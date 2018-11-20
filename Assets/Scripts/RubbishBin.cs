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
        hovering = true;
       // Debug.Log("Starting to hover");
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        StartCoroutine(LateBinHovering());
    }

    IEnumerator LateBinHovering()
    {
        yield return new WaitForEndOfFrame();
        hovering = false;
       // Debug.Log("Leaving Hover");
    }
}

