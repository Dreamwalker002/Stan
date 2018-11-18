using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanToExit : MonoBehaviour
{
    public float smoothSpeed;

    public Vector3 offSet;

    public Transform stuntExit;

    public Vector3 perviousPos;

    public Vector3 currentPos;




    public void ToExit()
    {
        Vector3 currentPos = transform.position;

        if (Input.GetMouseButton(0))
        {
            Vector3 desiredPosition = stuntExit.position + offSet;

            Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed * Time.deltaTime);

            transform.position = smoothedPosition;
        }

        if (Input.GetMouseButtonUp(0))
        {
            Vector3 desiredPosition = currentPos;

            Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed * Time.deltaTime);

            transform.position = smoothedPosition;
        }
    }
    // Vector3 currentPos = carmera.transform.position;






}


