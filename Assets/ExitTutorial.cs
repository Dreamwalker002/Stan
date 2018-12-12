using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ExitTutorial : MonoBehaviour {

    private void OnTriggerEnter(Collider other)
    {
        StartCoroutine(StartingUI());
    }

    IEnumerator StartingUI()
    {
        yield return new WaitForSeconds(2);
        TutorialPanel.tutorialPanelActive ++;
        SceneManager.LoadScene("MovieThemeScene");
    
    }
}
