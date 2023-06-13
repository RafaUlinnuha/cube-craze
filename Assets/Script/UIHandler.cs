using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;

public class UIHandler : MonoBehaviour
{
    public static UIHandler instance;

    public Text scoreText;
    public Text levelText;

    public GameObject gameOverWindow;

    void Awake()
    {
        instance = this;
    }

    void Start()
    {
        gameOverWindow.SetActive(false);
    }

    public void UpdateUI(int score, int level)
    {
        scoreText.text = "Score: " + score.ToString("D2");
        levelText.text = "Level: " + level.ToString("D2");
    }

    public void ActivateGameOverWindow()
    {
        gameOverWindow.SetActive(true);
    }
}
