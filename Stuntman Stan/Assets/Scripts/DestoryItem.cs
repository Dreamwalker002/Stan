using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestoryItem : MonoBehaviour
{
    public int crash = 0;

    public Renderer rend;

    public Collider col;

    private void OnTriggerEnter(Collider other)
    {
        crash++;

        rend = GetComponent<Renderer>();

        col = GetComponent<Collider>();

        if (crash >= 1)
        {           
            rend.enabled = false;

            col.enabled = false;          
        }

    }

}
