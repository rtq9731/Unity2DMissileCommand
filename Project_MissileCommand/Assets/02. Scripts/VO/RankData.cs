using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class RankData
{
    public List<DataClass> datas = new List<DataClass>();

    public void AddData(DataClass item)
    {
        datas.Add(item);
    }
}
