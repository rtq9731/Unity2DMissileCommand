using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;



public class GameManager : MonoSingleton<GameManager>
{

    public Vector2 maxPos = new Vector2(8.6f, 4.6f);
    public Vector2 minPos = new Vector2(-8.6f, -4.6f);

    List<DataClass> datas = new List<DataClass>();

    public enum TypesOfObj
    {
        Command,
        THAAD,
        Missile,
    }

    public void SaveData()
    {
        for (int i = 0; i < datas.Count; i++)
        {
            // PlayerPrefs.SetString($"{datas[i].id}", );
        }
    }

    public void LoadData()
    {

    }

    private bool CheckSaveFile()
    {
        return File.Exists(Application.persistentDataPath + "/TestSave.dat");
    }

    private void DeleteSave()
    {
        if (File.Exists(Application.persistentDataPath + "/TestSave.dat"))
        {
            File.Delete(Application.persistentDataPath + "/TestSave.dat");
            Debug.Log ("성공적으로 삭제하였습니다.");
            return;
        }
        else
        {
            Debug.Log("삭제에 실패하였습니다.");
            return;
        }

    }

    

}
