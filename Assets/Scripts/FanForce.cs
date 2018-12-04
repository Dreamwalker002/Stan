using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FanForce : MonoBehaviour
{

    //public Rigidbody stan;

    public AnimationCurve curve;

    public int force;

    public Drag dragScript;

    private void OnTriggerStay(Collider other)
    {
        if (dragScript.playermanagerScript.stanInPlay == true)
        {
            // Debug.Log("Blow");
            Vector3 forceDir = transform.forward;
            forceDir *= force * curve.Evaluate(Vector3.Distance(transform.position, other.transform.position));
            other.GetComponent<Rigidbody>().AddForce(forceDir, ForceMode.Acceleration);
        }
    }
}
