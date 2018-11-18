using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {


    public static GameManager instance = null;

   

      public LevelManager levelScript;



    //private int level;

    // Use this for initialization
    void Awake ()
    {
        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(gameObject);

        if (instance == this)
        {
            DontDestroyOnLoad(gameObject);
        }

        levelScript = GetComponent<LevelManager>();



      //  LoadLevel();

        
    }

    



}
