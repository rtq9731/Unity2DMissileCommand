using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[Serializable]
public class DataClass
{
    DataClass(int rank, string name, float score, string msg)
    {
        this.rank = rank;
        this.name = name;
        this.score = score;
        this.msg = msg;
    }

    int rank;
    string name;
    float score;
    string msg;
}
