using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;



public class GameManager : MonoSingleton<GameManager>
{

    public Vector2 maxPos = new Vector2(8.6f, 4.6f);
    public Vector2 minPos = new Vector2(-8.6f, -4.6f);

    public enum TypesOfObj
    {
        Command,
        THAAD,
        Missile,
    }

    public void SaveData()
    {
        PlayerPrefs.SetFloat("Score", MainSceneManager.Instance.score);
        PlayerPrefs.SetFloat("surviveTime", MainSceneManager.Instance.surviveTime);
        PlayerPrefs.Save();
    }

    public void LoadData()
    {
        PlayerPrefs.GetFloat("Score", MainSceneManager.Instance.score);
        PlayerPrefs.GetFloat("surviveTime", MainSceneManager.Instance.surviveTime);
    }

}
