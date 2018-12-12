using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stunthardcode : MonoBehaviour
{

    public GameManager gameManager;

    public StoredInformation storedinfo;

    public GameObject stuntSelection1;

    public GameObject stuntSelection2;

    public GameObject stuntSelection3;

    public GameObject stuntSelection4;

    public GameObject stuntSelection5;

    private void Awake()
    {
        gameManager = GameManager.instance;

        storedinfo = gameManager.GetComponent<StoredInformation>();

        ActiveScenes();
    }


    void ActiveScenes()
    {

        if (storedinfo.stuntEnd >= 1)
        {
            stuntSelection1.SetActive(false);
        }
        if (storedinfo.stuntEnd >= 2)
        {
            stuntSelection2.SetActive(false);
        }
        if (storedinfo.stuntEnd >= 3)
        {
            stuntSelection3.SetActive(false);
        }
        if (storedinfo.stuntEnd >= 4)
        {
            stuntSelection4.SetActive(false);
        }
        if (storedinfo.stuntEnd >= 5)
        {
            stuntSelection5.SetActive(false);
        }
    }
}
