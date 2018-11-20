using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionCamera : MonoBehaviour
{

    public bool entered;

    private void OnTriggerEnter(Collider other)
    {        
        entered = true;
    }


}


