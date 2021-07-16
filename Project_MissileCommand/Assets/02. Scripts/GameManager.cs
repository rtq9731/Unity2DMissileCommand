using System.IO;
using System.Text;
using System.Collections.Generic;
using UnityEngine;



public class GameManager : MonoSingleton<GameManager>
{

    public Vector2 maxPos = new Vector2(8.6f, 4.6f);
    public Vector2 minPos = new Vector2(-8.6f, -4.6f);

    public RankData datas;
    private string jsonString;


    public void SaveData()
    {
        jsonString = JsonUtility.ToJson(datas);
        FileStream fs = new FileStream(Application.persistentDataPath + "/save.dat", FileMode.Create);
        byte[] data = Encoding.UTF8.GetBytes(jsonString);
        fs.Write(data, 0, data.Length);
        fs.Close();
        Debug.Log("JSON : " + jsonString);
    }

    public void LoadData() 
    {
        FileStream fs = new FileStream(Application.persistentDataPath + "/save.dat", FileMode.Open);
        byte[] data = new byte[fs.Length];
        fs.Read(data, 0, data.Length);
        fs.Close();
        jsonString = Encoding.UTF8.GetString(data);
        datas = JsonUtility.FromJson<RankData>(jsonString);
    }

    public bool CheckSaveFile()
    {
        return File.Exists(Application.persistentDataPath + "/TestSave.dat");
    }

    public void DeleteSave()
    {
        if (CheckSaveFile())
        {
            File.Delete(Application.persistentDataPath + "/TestSave.dat");
            Debug.Log ("���������� �����Ͽ����ϴ�.");
            return;
        }
        else
        {
            Debug.Log("������ �����Ͽ����ϴ�.");
            return;
        }

    }

    

}
