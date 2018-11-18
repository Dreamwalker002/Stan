using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemCost : MonoBehaviour {

    public int cost;

    private void Awake()
    {

        Score.instance.thecurrentCost += cost;
    }

    public void Refund()
    {
        Score.instance.thecurrentCost -= cost;
    }

}
