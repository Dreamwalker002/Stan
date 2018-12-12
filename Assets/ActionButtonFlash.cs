using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ActionButtonFlash : MonoBehaviour
{
    private Color color;
    public Image image;

    public GameObject action;
    public GameObject block;

    public PlayerManager playerManagerScript;

    private bool flashSwitch;

    public GameObject itemPanel;

    public int tutBlock;

    void Start()

    {
        image = action.GetComponent<Image>();
        color = image.color;
        itemPanel.SetActive(true);
    }

    void Update()
    {
        //color.a = Mathf.PingPong( Time.time, 1);
        if ((playerManagerScript.stanInPlay == false) && (flashSwitch == false))
        {
            color.a = (Mathf.Sin(Time.time * 5f) + 1f) / 2;
            image.color = color;
        }
        else if ((playerManagerScript.stanInPlay == true) && (flashSwitch == false))
        {
            flashSwitch = true;
            color.a = 1f;
            image.color = color;
            itemPanel.SetActive(false);
        }

        if ((playerManagerScript.stanInPlay == false) && (flashSwitch == true))
        {
            if (tutBlock <= 0f)
            {
                image = block.GetComponent<Image>();
                color.a = (Mathf.Sin(Time.time * 5f) + 1f) / 2;
                image.color = color;
            }
            else
            {
                color.a = 1f;
                image.color = color;
            }
        }

    }

    public GameObject tutBlockPrefab;
    public GameObject stunItems;
    private Vector3 location;

    void StunItems()

    {
        stunItems = Instantiate(tutBlockPrefab, (location), transform.rotation);
        tutBlock++;
    }

    /// //////////////////////////////////////////////////////////////////////////////////////////

    public void ItemOne()
    {
        Destroy(stunItems);
        location = UnityEngine.Camera.main.ScreenToWorldPoint(Input.mousePosition);
        StunItems();
    }
}
