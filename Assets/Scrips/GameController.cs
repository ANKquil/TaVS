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

}