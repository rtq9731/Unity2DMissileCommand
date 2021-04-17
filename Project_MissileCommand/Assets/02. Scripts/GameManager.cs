using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;



public class GameManager : MonoSingleton<GameManager>
{

    public float score = 0;
    public float surviveTime = 0f;

    public List<GameObject> missileList;
    public List<GameObject> defenseMissileList;

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
        PlayerPrefs.SetFloat("Score", score);
        PlayerPrefs.SetFloat("surviveTime", surviveTime);
        PlayerPrefs.Save();
    }

    public void LoadData()
    {
        PlayerPrefs.GetFloat("Score", score);
        PlayerPrefs.GetFloat("surviveTime", surviveTime);
    }

}
