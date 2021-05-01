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

    public static void SaveData<T>(T instance)
    {
        using (var ms = new MemoryStream())
        {
            new BinaryFormatter().Serialize(ms, instance);
            for (int i = 0; i < datas.Count; i++)
            {
                PlayerPrefs.SetString("Datas" + i.ToString(), System.Convert.ToBase64String(ms.ToArray()));
            }

        }
    }

    public void LoadData()
    {
    }

    private bool CheckSaveFile()
    {
        return File.Exists(Application.persistentDataPath + "/TestSave.dat");
    }

}
