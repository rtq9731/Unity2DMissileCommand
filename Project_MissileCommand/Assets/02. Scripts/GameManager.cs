using System.IO;
using System.Text;
using System.Collections.Generic;
using UnityEngine;



public class GameManager : MonoSingleton<GameManager>
{

    public Vector2 maxPos = new Vector2(8.6f, 4.6f);
    public Vector2 minPos = new Vector2(-8.6f, -4.6f);

    public List<DataClass> datas = new List<DataClass>();
    private string jsonString;

    public enum TypesOfObj
    {
        Command,
        THAAD,
        Missile,
    }

    public void SaveData()
    {
        jsonString = JsonUtility.ToJson(datas);
        FileStream fs = new FileStream(Application.persistentDataPath + "/TestSave.dat", FileMode.Create);
        byte[] data = Encoding.UTF8.GetBytes(jsonString);
        fs.Write(data, 0, data.Length);
        fs.Close();
        Debug.Log("JSON : " + jsonString);
    }

    public void LoadData()
    {
        FileStream fs = new FileStream(Application.persistentDataPath + "/TestSave.dat", FileMode.Open);
        byte[] data = new byte[fs.Length];
        fs.Read(data, 0, data.Length);
        fs.Close();
        jsonString = Encoding.UTF8.GetString(data);
        datas = JsonUtility.FromJson<List<DataClass>>(jsonString);
    }

    private bool CheckSaveFile()
    {
        return File.Exists(Application.persistentDataPath + "/TestSave.dat");
    }

    public void DeleteSave()
    {
        if (CheckSaveFile())
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
