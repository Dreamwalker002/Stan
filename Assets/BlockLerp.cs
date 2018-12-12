using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockLerp : MonoBehaviour {

    public Vector3 targetPos;

    float Speed = 2;

void Update ()
    {

        Vector3 desiredPosition = targetPos;

        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, Speed * Time.deltaTime);
        transform.position = smoothedPosition;

    }
}
