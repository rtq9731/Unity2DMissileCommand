using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[Serializable]
public class DataClass
{
    public int id;
    public int rank;
    public string name;
    public float score;
    public string msg;

    DataClass(int rank, string name, float score, string msg, int id)
    {
        this.rank = rank;
        this.name = name;
        this.score = score;
        this.msg = msg;
        this.id = id;
    }
}
