using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public LevelInformation information;

    public LevelManager levelManagerScript;

    public GameManager gameManager;

    public Text budget;

    public Text endbudget;

    public Text currentCost;

    public Text eggScore;

    public Text peopleScore;

    public Text endCost;

    public float thebudget;

    public float theEggScore;

    public float onBudget;

    public float thecurrentCost;

    public int totalCamShots;

    public int finalEggScore;

    public float actionCamerasPassedThroughfloat;

    public float totalActionCamerasfloat;

    public float audScore;

    public int finalPeopleScore;

    public int finalPeopleScoreint;

    public int camEntered;

    public StoredInformation storedinfo;

    public Color color;

    public static Score instance;

    public GameObject exit;

    public int stuntEnd = 1;

    public bool movieReview = false;




    void Awake()
    {
        instance = this;

        gameManager = GameManager.instance;

        storedinfo = gameManager.GetComponent<StoredInformation>();

        levelManagerScript = gameManager.GetComponent<LevelManager>();


        budget.text = information.budget.ToString();

        endbudget.text = information.budget.ToString();

        thebudget = information.budget;

        currentCost.text = thecurrentCost.ToString();

        endCost.text = thecurrentCost.ToString();

        thecurrentCost = information.currentCost;

        storedinfo.totalBudget += information.budget;

        


        color = currentCost.color;
        //// find fix for replaying and score////

        if (information.stuntEnd == true)
        {
            
            storedinfo.totalBudget -= thebudget;
            storedinfo.totalStuntCost -= thecurrentCost;
            thecurrentCost = 0;
            storedinfo.stuntEnd -= stuntEnd;
        }

    }

    private void Update()
    {
        if (thecurrentCost >= thebudget)
        {
            color = Color.red;
            currentCost.color = color;
        }

        else
        {
            color = Color.white;
            currentCost.color = color;

        }

        currentCost.text = thecurrentCost.ToString();
        endCost.text = thecurrentCost.ToString();
        endCost.color = color;

        OnBudget();

        if (storedinfo.stuntEnd >= 6 == true)
        {
            MovieReview();
        }


    }
    void OnBudget()
    {
        onBudget = thecurrentCost / thebudget;
    }

    void MovieReview()
    {

        theEggScore = ((storedinfo.totalStuntCost / storedinfo.totalBudget) * 100);
        finalEggScore = Mathf.RoundToInt(theEggScore);
        eggScore.text = finalEggScore.ToString();


        finalPeopleScoreint = ((storedinfo.actionCamerasPassedThrough / storedinfo.totalActionCameras));

        actionCamerasPassedThroughfloat = Mathf.Round(storedinfo.actionCamerasPassedThrough);
        totalActionCamerasfloat = Mathf.Round(storedinfo.totalActionCameras);

        audScore = ((actionCamerasPassedThroughfloat / totalActionCamerasfloat) * 100);
        finalPeopleScore = Mathf.RoundToInt(audScore);


        peopleScore.text = finalPeopleScore.ToString();

    }

}
