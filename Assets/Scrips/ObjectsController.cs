using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ObjectsController : MonoBehaviour
{
    public GameObject[] blocks;

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

    public bool IsActive(string num)
    {
        bool allow = false;
        switch (num)
        {
            case "11":
                allow = blocks[0].GetComponent<BlockController>().IsActive();
                break;
            case "12":
                allow = blocks[1].GetComponent<BlockController>().IsActive();
                break;
            case "13":
                allow = blocks[2].GetComponent<BlockController>().IsActive();
                break;
            case "21":
                allow = blocks[3].GetComponent<BlockController>().IsActive();
                break;
            case "22":
                allow = blocks[4].GetComponent<BlockController>().IsActive();
                break;
            case "23":
                allow = blocks[5].GetComponent<BlockController>().IsActive();
                break;
            case "31":
                allow = blocks[6].GetComponent<BlockController>().IsActive();
                break;
            case "32":
                allow = blocks[7].GetComponent<BlockController>().IsActive();
                break;
            case "33":
                allow = blocks[8].GetComponent<BlockController>().IsActive();
                break;
        }
        return allow;
    }

    public void SetActiveWin(bool b)
    {
        for (int i = 0; i < winUI.Length; i++)
        {
            winUI[i].SetActive(b);
        }
    }

    public void SetBlock(string num, int i)
    {
        switch (num)
        {
            case "11":
                blocks[0].GetComponent<BlockController>().SetActiveBlock(i);
                break;
            case "12":
                blocks[1].GetComponent<BlockController>().SetActiveBlock(i);
                break;
            case "13":
                blocks[2].GetComponent<BlockController>().SetActiveBlock(i);
                break;
            case "21":
                blocks[3].GetComponent<BlockController>().SetActiveBlock(i);
                break;
            case "22":
                blocks[4].GetComponent<BlockController>().SetActiveBlock(i);
                break;
            case "23":
                blocks[5].GetComponent<BlockController>().SetActiveBlock(i);
                break;
            case "31":
                blocks[6].GetComponent<BlockController>().SetActiveBlock(i);
                break;
            case "32":
                blocks[7].GetComponent<BlockController>().SetActiveBlock(i);
                break;
            case "33":
                blocks[8].GetComponent<BlockController>().SetActiveBlock(i);
                break;
        }
    }

    public void SetAllBlocks(int num)
    {
        for (int i = 0; i < blocks.Length; i++)
        {
            blocks[i].GetComponent<BlockController>().SetActiveBlock(num);
        }
    }

}