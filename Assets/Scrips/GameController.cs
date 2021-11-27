using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    ObjectsController objectsController;

    int[,] Allow = { { 0, 0, 0 }, { 0, 0, 0 }, { 0, 0, 0 } };
    public List<string> listKrestiks = new List<string>();
    public List<string> listNoliks = new List<string>();
    bool krestik = true;
    bool bot = false;
    int clicks = 0;
    public int playerNow = 0;

    bool win = false;
    int player1Score = 0;
    int player2Score = 0;
    int botScore = 0;


    void Start()
    {
        objectsController = gameObject.GetComponent<ObjectsController>();
        bot = Convert.ToBoolean(PlayerPrefs.GetInt("bot"));
        objectsController.SetScore(1, 0.ToString());
        if (bot)
            objectsController.SetScore(0, 0.ToString());
        else
            objectsController.SetScore(2, 0.ToString());
    }


    void Update()
    {
    }


    void TouchController()
    {
        RaycastHit hit;

        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider != null)
                {
                    //Choose(hit.collider.name, false);
                }
            }
        }
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            Ray ray = Camera.main.ScreenPointToRay(touch.position);

            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider != null)
                {
                    //Choose(hit.collider.name, false);
                }
            }
        }
    }


    int Choose(string name, bool b)
    {
        int x = (Convert.ToInt32(name) / 10) % 10 - 1;
        int y = Convert.ToInt32(name) % 10 - 1;

        if (Allow[x, y] != 0) return 0;

        if (krestik)
        {
           // objectsController.SetBlock(name, 1);
            Allow[x, y] = 1;
            listKrestiks.Add(name);
            //CheckWin();
        }
        else
        {
            //objectsController.SetBlock(name, 2);
            Allow[x, y] = 2;
            listNoliks.Add(name);
            //CheckWin();
        }
        if (win) return 0;

        clicks++;
        if (clicks >= 9)
        {
            //Reset();
        }
        krestik = !krestik;

        if (bot)
        {
            if (!b)
            {
                playerNow = 0;
                //BotChoose();
            }
        }
        else
        {
            if (playerNow == 1)
                playerNow = 2;
            else
                playerNow = 1;
        }
        return 0;
    }


    readonly string[,] winCombinations = {
        {"11", "12", "13"},{"21", "22", "23"},{"31", "32", "33"},
        {"11", "22", "33"},{"12", "22", "32"},{"13", "23", "33"},
        {"11", "22", "33"},{"13", "22", "31"},{"11", "21", "31"}
    };


    int CheckWin()
    {
        if (krestik)
        {
            for (int i = 0; i < winCombinations.Length / 3; i++)
            {
                bool[] next = { false, false, false };
                foreach (string str in listKrestiks)
                {
                    if (winCombinations[i, 0] == str) next[0] = true;
                    if (winCombinations[i, 1] == str) next[1] = true;
                    if (winCombinations[i, 2] == str) next[2] = true;
                }
                if (next[0] == true && next[1] == true && next[2] == true)
                {
                    win = true;
                    //SetWiner(1, player1Score++);
                    return 1;
                }
            }
        }
        else
        {
            for (int i = 0; i < winCombinations.Length / 3; i++)
            {
                bool[] next = { false, false, false };
                foreach (string str in listNoliks)
                {
                    if (winCombinations[i, 0] == str) next[0] = true;
                    if (winCombinations[i, 1] == str) next[1] = true;
                    if (winCombinations[i, 2] == str) next[2] = true;
                }
                if (next[0] == true && next[1] == true && next[2] == true)
                {
                    win = true;
                    //if (bot) SetWiner(0, botScore++);
                    //else SetWiner(2, player2Score++);
                    return 2;
                }
            }
        }
        return 0;
    }


    void SetWiner(int player, int score)
    {
        score++;
        objectsController.SetScore(player, text: score.ToString() + "\nWIN");
        objectsController.SetActiveWin(true);
    }


    public void Reset()
    {
        win = false;
        clicks = 0;
        playerNow = 0;
        krestik = true;
        listKrestiks.Clear();
        listNoliks.Clear();
        Allow = new int[,] { { 0, 0, 0 }, { 0, 0, 0 }, { 0, 0, 0 } };
        //objectsController.SetAllBlocks(0);
        objectsController.SetActiveWin(false);
        objectsController.SetScore(1, player1Score.ToString());
        if (bot)
            objectsController.SetScore(0, botScore.ToString());
        else
            objectsController.SetScore(2, player2Score.ToString());
    }
}