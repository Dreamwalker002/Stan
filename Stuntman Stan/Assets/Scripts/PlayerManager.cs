using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerManager : MonoBehaviour
{
    public bool stanInPlay;

    public GameObject [] uncrash;

    public Rigidbody stan;

    public Vector3 trajectory;

    public int force;

    private bool crashMat;
    
    public CameraMovement carmeraMovement;

    public float countdownTimer;

    public void OnDrawGizmos()
    {
        Gizmos.DrawLine(transform.position, transform.position + trajectory.normalized * force);
    }

    public void Action()
    {
        Time.timeScale = 1;
        StartCoroutine(StartingTimer());

      //  Debug.Log(stanInPlay);
      //  Debug.Log("StartingTimer");

    }

    IEnumerator StartingTimer()
    {
       // Debug.Log("Test");
        yield return new WaitForSeconds(2);

        carmeraMovement.minX = carmeraMovement.minX - 20f;
        carmeraMovement.maxX = carmeraMovement.maxX + 20f;
        carmeraMovement.minY = carmeraMovement.minY - 20f;
        carmeraMovement.maxY = carmeraMovement.maxY + 20f;

        stanInPlay = true;
      //  Debug.Log(stanInPlay);

        carmeraMovement.smoothSpeed = 1.2f;
        
        yield return new WaitForSeconds(countdownTimer - 1);

        carmeraMovement.smoothSpeed = 6f;
        
        stan.AddForce(trajectory.normalized * force, ForceMode.VelocityChange);

        stan.useGravity = true;
        
    }
    void Uncrash()
    {
        uncrash = GameObject.FindGameObjectsWithTag("CrashMat");

        foreach (GameObject f in uncrash)
        {
            f.GetComponent<MeshRenderer>().enabled = true;
        }
        foreach (GameObject f in uncrash)
        {
            f.GetComponent<Collider>().enabled = true;
        }
    }

    public void Restart()
    {
        Uncrash();
        stan.transform.position = new Vector3(-48.45f, 1f, 0);
        stan.useGravity = false;
        stan.velocity = Vector3.zero;
        stanInPlay = false;
    }

    private void OnTriggerEnter(Collider other)
    {

        if ((stan.velocity.magnitude >= 4) && (other.gameObject.tag == "building"))
        {
            //Debug.Log("spat");
        }

            if (other.gameObject.tag == "Finish")
            {
                StartCoroutine(LevelEnd());

            }
        }


    IEnumerator LevelEnd()
    {
        stanInPlay = false;
        yield return new WaitForSeconds(3);
        Time.timeScale = 0.7f;
    }
    

    private void OnCollisionEnter(Collision collision)
    {
        if ((collision.relativeVelocity.magnitude >= 8) && (collision.collider.gameObject.tag == "building"))
        {
           // Debug.Log("spat");
           // Debug.Log(collision.relativeVelocity.magnitude);
        }

        if (collision.collider.gameObject.tag == "FinishStunt")
        {
            Restart();
        }
    }

   
 

}

