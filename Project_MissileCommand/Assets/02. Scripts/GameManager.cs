using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class GameManager : MonoSingleton<GameManager>
{
    public List<GameObject> missileList;

    public Vector2 maxPos = new Vector2(8.6f, 4.6f);
    public Vector2 minPos = new Vector2(-8.6f, -4.6f);

    public enum TypesOfObj
    {
        Command,
        THAAD,
        Missile,
    }

}
