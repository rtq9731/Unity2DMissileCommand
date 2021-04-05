using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cursor : MonoBehaviour
{
    [SerializeField]
    Camera mainCam = null;

    void Update()
    {
        transform.position = new Vector2(mainCam.ScreenToWorldPoint(Input.mousePosition).x, mainCam.ScreenToWorldPoint(Input.mousePosition).y);
    }
}
