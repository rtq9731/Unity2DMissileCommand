using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[Serializable]
public class DataClass
{
    public string name;
    public float score;
    public string msg;

    public DataClass(string name, float score, string msg)
    {
        this.name = name;
        this.score = score;
        this.msg = msg;
    }
}
