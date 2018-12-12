using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TutorialLevelScreen : MonoBehaviour
{
    public void ToMenu()
    {
        SceneManager.LoadScene("HomeScene");
    }

    public void ToTutorialLevel()
    {
        SceneManager.LoadScene("Tutorial0");
    }
}
