using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ObjectsController : MonoBehaviour
{
    public GameObject[] scoreUI;

    public GameObject[] winUI;

    public void LoadMenuScene()
    {
        SceneManager.LoadScene("Menu");
    }

    public void SetScore(int player, string text)
    {
        switch (player)
        {
            case 0:
                scoreUI[1].GetComponent<Text>().text = "Bot\n" + text;
                break;
            case 1:
                scoreUI[0].GetComponent<Text>().text = "Player1\n" + text;
                break;
            case 2:
                scoreUI[1].GetComponent<Text>().text = "Player2\n" + text;
                break;
        }
    }

    public void SetActiveWin(bool b)
    {
        for (int i = 0; i < winUI.Length; i++)
        {
            winUI[i].SetActive(b);
        }
    }
}
