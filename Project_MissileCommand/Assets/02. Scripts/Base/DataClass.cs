using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[Serializable]
public class DataClass
{
    [SerializeField] public string name;
    [SerializeField] public string msg;
    [SerializeField] public float score;
    [SerializeField] public float surviveTime;

    public DataClass(string name, float score, string msg, float surviveTime)
    {
        this.name = name;
        this.score = score;
        this.msg = msg;
        this.surviveTime = surviveTime;
    }
}
