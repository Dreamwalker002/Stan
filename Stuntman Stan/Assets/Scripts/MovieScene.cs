using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MovieScene : MonoBehaviour
{

    public bool entered;

   

   

    private void OnTriggerEnter(Collider other)
    {

        //Debug.Log("entered");
        entered = true;

    }


}
