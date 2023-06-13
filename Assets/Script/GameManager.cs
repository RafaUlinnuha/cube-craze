using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    int score;
    int level;
    int layersCleared;

    bool gameIsOver;

    float fallSpeed;

    void Awake()
    {
        instance = this;
    }

    void Start()
    {
        SetScore(score);
    }

    public void SetScore(int amount)
    {
        score += amount;
        CalculateLevel();
        UIHandler.instance.UpdateUI(score, level);
        //UPDATE UI
    }

    public float ReadFallSpeed()
    {
        return fallSpeed;
    }

    public void LayersCleared(int amount)
    {
        if(amount == 1)
        {
            SetScore(10);
        }
        else if (amount == 2)
        {
            SetScore(20);
        }
        else if (amount == 3)
        {
            SetScore(30);
        }
        else if (amount == 4)
        {
            SetScore(40);
        }

        layersCleared += amount;

        //UPDATE UI
        UIHandler.instance.UpdateUI(score, level);
    }

    void CalculateLevel()
    {
        if(score <= 50)
        {
            level = 1;
            fallSpeed = 3f;
        }
        else if (score > 50 && score <= 100)
        {
            level = 2;
            fallSpeed = 2.75f;
        }
        else if (score > 100 && score <= 150)
        {
            level = 3;
            fallSpeed = 2.5f;
        }
        else if (score > 150 && score <= 200)
        {
            level = 4;
            fallSpeed = 2.25f;
        }
        else if (score > 200 && score <= 250)
        {
            level = 5;
            fallSpeed = 2f;
        }
        else if (score > 250 && score <= 300)
        {
            level = 6;
            fallSpeed = 1.75f;
        }
        else if (score > 300 && score <= 350)
        {
            level = 7;
            fallSpeed = 1.5f;
        }
        else if (score > 350 && score <= 400)
        {
            level = 8;
            fallSpeed = 1.25f;
        }
        else if (score > 450 && score <= 500)
        {
            level = 9;
            fallSpeed = 1f;
        }
        else if (score > 500)
        {
            level = 10;
            fallSpeed = 0.75f;
        }
    }

    public bool ReadGameIsOver()
    {
        return gameIsOver;
    }

    public void SetGameIsOver()
    {
        gameIsOver = true;
        UIHandler.instance.ActivateGameOverWindow();
    }
}
