using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOverPanel : MonoBehaviour
{
    [SerializeField]
    Button restartBtn;
    [SerializeField]
    Button quitBtn;
    [SerializeField]
    Button mainMenuBtn;
    [SerializeField]
    Text scoreText;
    [SerializeField]
    Text timeText;

    private void Awake()
    {
        restartBtn.onClick.AddListener(RestartGame);
        quitBtn.onClick.AddListener(Quit);
        mainMenuBtn.onClick.AddListener(LoadMainScene);
    }

    private void LoadMainScene()
    {
        SceneManager.LoadScene("01. Start");
    }

    private void Quit()
    {
        Application.Quit();
    }

    private void RestartGame()
    {
        SceneManager.LoadScene("02. MainScene");
    }

    private void OnEnable()
    {
        scoreText.text = "ScoreText : " + MainSceneManager.Instance.score.ToString();
        timeText.text = "Survive Time : " + MainSceneManager.Instance.surviveTime.ToString();
    }

}
