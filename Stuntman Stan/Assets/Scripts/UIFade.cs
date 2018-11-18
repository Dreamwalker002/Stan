using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIFade : MonoBehaviour
{

    public void TheBeginning()
    {
            SceneManager.LoadScene("HomeScene");

    }

    public void Play()
    {
        SceneManager.LoadScene("MovieThemeScene");
    }


}
