using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Music : MonoBehaviour
{
    public GameManager gameManager;

    public Toggle soundToggle;

    public AudioSource gameMusic;

    private void Awake()
    {
        gameManager = GameManager.instance;
        gameMusic = gameManager.GetComponent <AudioSource>();
        soundToggle = GetComponent<Toggle>();
        

        if (gameMusic.mute == true)
        {
           // Debug.Log("Test");
            
            soundToggle.isOn = true;
            gameMusic.mute = true;
        }
    }

   

	public void MusicOnOff()
    {
        if (gameMusic.mute == true)
        {
            gameMusic.mute = false;
        }

        else if (gameMusic.mute == false)
        {
            gameMusic.mute = true;
        }

    }

}
