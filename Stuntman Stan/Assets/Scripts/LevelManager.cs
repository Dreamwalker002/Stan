using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class LevelManager : MonoBehaviour {

   // public LevelInformation[] levelInformation;

    public LevelInformation information;

    public List<string> movieNames;

    public int level;

    public float budget;

    public float currentCost;

    public int score;

    public int camShots;

    public string levelName;

    public Sprite stuntPoster;

    public GameObject themePanel;

    public GameObject stuntPanel;

    public Scene currentScene;

    public string sceneName;

    // Use this for initialization
    void Awake ()
    {
      
       // information = levelInformation[1];

        //levelName = information.levelName;

        //level = information.level;

       // budget = information.budget;

       // currentCost = information.currentCost;

        //score = information.score;

        //camShots = information.camShots;

        //stuntPoster = information.stuntPoster;

        //movieName.Add("Test movie");
        

       
        levelName = "MovieStunt";

        currentScene = SceneManager.GetActiveScene();
        sceneName = currentScene.name;

    }

    public void Theme(int num)
    {
        levelName = movieNames[num];      
        themePanel.SetActive(false);
        stuntPanel.SetActive(true);
    }

    public void BackToStunts(int num)
    {
        levelName = movieNames[num];
        SceneManager.LoadScene("MovieThemeScene");
        themePanel.SetActive(false);
        stuntPanel.SetActive(true);
        print("why you not working");
    }

    public void Stunt(int num)
    {
        SceneManager.LoadScene(levelName + num);       
    }

    public void ToMenu()
    {
        SceneManager.LoadScene("HomeScene");
    }

    public void ResetCurrentLevel()
    {
       // Debug.Log("Reset");
        Debug.Log(currentScene.name);
        SceneManager.LoadScene(currentScene.name);
        sceneName = currentScene.name;
    }

}
	
	

