using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Exit : MonoBehaviour
{
    public int stuntStars;

    public GameObject[] starsObjects;

    public Score score;

    public bool entered;

    public GameObject endOfStunt;

    public GameObject endOfMovie;

    public int camShotHit = 0;

    public int bestCamScore = 0;

    public int allcameras = 0;

    public float onBudget;

    public string sceneName;

    /////////////////////////////////////////////////////////////////////////////////////////////

    private void OnTriggerEnter(Collider other)
    {

        GetCamsEntered();

        if (score.information.stuntEnd == false)
        {
            LevelDone();
        }

        else
        {
            stuntStars = 0;
            score.storedinfo.actionCamerasPassedThrough -= score.information.currentCamHit;
            LevelRedone();
        }

        Stars();

        TotalCameras();

        score.information.stars = stuntStars;

        endOfStunt.SetActive(true);

        Time.timeScale = 0;

    }

    /////////////////////////////////////////////////////////////////////////////////////////////

    public int GetCamsEntered()
    {
        ActionCamera[] cams = FindObjectsOfType<ActionCamera>();

        for (int i = 0; i < cams.Length; i++)
        {
            if (cams[i].entered == true)
            {
                camShotHit += 1;
            }
        }
        allcameras = cams.Length;
        return camShotHit;
    }

    /////////////////////////////////////////////////////////////////////////////////////////////

    void TotalCameras()
    {
        if (camShotHit >= bestCamScore)
        {
            bestCamScore = camShotHit;
        }
    }

    /////////////////////////////////////////////////////////////////////////////////////////////

    void Stars()
    {
        onBudget = score.onBudget;

        if ((camShotHit >= 4) && (onBudget <= .5f))
        {
            stuntStars = 3;
        }

        else if ((camShotHit >= 3) && (onBudget <= .75f))
        {
            stuntStars = 2;
        }

        else
        {
            stuntStars = 1;
        }

        //Loop through each star that player has won and set it to be active
        for (int i = 0; i < stuntStars; i++)
        {
            starsObjects[i].SetActive(true);
        }

    }

    /////////////////////////////////////////////////////////////////////////////////////////////

    void LevelDone()
    {
        score.information.stuntEnd = true;
        score.storedinfo.stuntEnd++;
        score.storedinfo.totalActionCameras += allcameras;
        score.storedinfo.actionCamerasPassedThrough += camShotHit;
        score.information.currentCamHit = camShotHit; //store cams hit

        score.storedinfo.totalStuntCost += score.thecurrentCost;//store stunt cost
        score.information.currentCost = score.thecurrentCost;
    }

    /////////////////////////////////////////////////////////////////////////////////////////////

    void LevelRedone()
    {

        score.storedinfo.actionCamerasPassedThrough += camShotHit;
        score.information.currentCamHit = camShotHit; //store cams hit

        score.storedinfo.totalStuntCost += score.thecurrentCost;//store stunt cost
        score.information.currentCost = score.thecurrentCost;
    }

    /////////////////////////////////////////////////////////////////////////////////////////////

 }
