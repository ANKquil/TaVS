using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockController : MonoBehaviour
{
    public GameObject krestik;
    public GameObject nolik;

    bool active = false;

    public void SetActiveBlock(int i)
    {
        if (i == 1)
        {
            krestik.SetActive(true);
            active = true;
        }
        else if (i == 2)
        {
            nolik.SetActive(true);
            active = true;
        }
        else
        {
            krestik.SetActive(false);
            nolik.SetActive(false);
            active = false;
        }
    }
}
