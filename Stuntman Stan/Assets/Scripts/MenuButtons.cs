using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class MenuButtons : MonoBehaviour
{

    public GameManager gameManager;

    public Scene currentScene;

    public string sceneName;

    public LevelManager info;

    public StoredInformation storedinfo;

    public Score scoreScript;

    public Text eggScore;

    int eggScoreint;

    float eggScorefloat;

    public Text peopleScore;

    public GameObject themePanel;

    public GameObject stuntPanel;

    public GameObject endOfStunt;

    public GameObject endOfMovie;

    public GameObject stuntSelection1;

    public GameObject stuntSelection2;

    public GameObject stuntSelection3;

    public GameObject stuntSelection4;

    public GameObject stuntSelection5;


    // Use this for initialization
    private void Awake()
    {
        gameManager = GameManager.instance;

        info = gameManager.GetComponent<LevelManager>();

        scoreScript = gameManager.GetComponent<Score>();

        currentScene = SceneManager.GetActiveScene();

        storedinfo = gameManager.GetComponent<StoredInformation>();

        sceneName = currentScene.name;

        themePanel = info.themePanel;

        stuntPanel = info.stuntPanel;

        ActiveScenes();

    }


    public void Stunt(int num)
    {
        SceneManager.LoadScene(info.levelName + num);
    }

    public void ReturnToStunt(int num)
    {
        
            SceneManager.LoadScene("MovieThemeScene");
        
    }

    public void ReturnToStunts(int num)
    {
        if (storedinfo.stuntEnd >= 5)
        {
            endOfMovie.SetActive(true);
            endOfStunt.SetActive(false);
            scoreScript.movieReview = true;
            //  EndScreen();
        }
        else
        {
            SceneManager.LoadScene("MovieThemeScene");
        }
    }

    public void ToMenu()
    {
        SceneManager.LoadScene("HomeScene");
    }

    public void ResetCurrentLevel()
    {
        scoreScript.thecurrentCost = 0;
        SceneManager.LoadScene(currentScene.name);
    }

    void ActiveScenes()
    {
        for (int i = 0; i < storedinfo.stuntEnd; i++)
        {
            stuntSelection1.SetActive(false);
            Debug.Log("reset me after current job");               
        }
    }

    void EndScreen()
    {
        Debug.Log("i am alive in here");
        scoreScript.movieReview = true;

        eggScorefloat = ((storedinfo.totalStuntCost / storedinfo.totalBudget) * 100);
        eggScoreint = Mathf.RoundToInt(eggScorefloat);
        eggScore.text = eggScoreint.ToString();

        peopleScore.text = ((storedinfo.actionCamerasPassedThrough / storedinfo.totalActionCameras) * 100).ToString();
        Debug.Log(eggScorefloat+"eggScorefloat");
        Debug.Log(eggScoreint+ "eggScoreint");
    }
}
