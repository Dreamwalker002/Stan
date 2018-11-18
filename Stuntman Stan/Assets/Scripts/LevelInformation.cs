using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "New Level Information", menuName = "Level Information")]

public class LevelInformation : ScriptableObject
{
    public string levelName;

    public int level;

    public float budget;

    public float currentCost;

    public int currentCamHit;

    public int stars;

    public bool stuntEnd;


   

}
