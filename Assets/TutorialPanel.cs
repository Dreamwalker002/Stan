using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialPanel : MonoBehaviour {

    public GameObject tutorialPanel;

    public static int tutorialPanelActive = 0;
    // Use this for initialization
    void Awake ()
    {
        TutorialPanelActive();
        Debug.Log(tutorialPanelActive);
    }
	
	void TutorialPanelActive()
    {
        if (tutorialPanelActive == 0)
        {
            tutorialPanel.SetActive(true);
        }

        else
        {
            tutorialPanel.SetActive(false);
        }
    }
}

