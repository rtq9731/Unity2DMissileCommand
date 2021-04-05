using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMissile : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    private double speed = 1;

    private Vector2 targetPosition = Vector2.zero;

    void OnEnable()
    {

        

        double tx = targetPosition.x;
        double ty = targetPosition.y;
        double x = transform.position.x;
        double y = transform.position.y;


        double dx = tx - x;
        double dy = ty - y;
        double d = Math.Sqrt(dx * dx + dy * dy);

        double vx = 0;
        double vy = 0;

        if (d > 1)
        {
            vx = dx / d;
            vy = dy / d;
        }

        transform.rotation = Quaternion.Euler(new Vector2((float)vx, (float)vy));

        //x -= vx * speed * Time.deltaTime;
        //y -= vy * speed * Time.deltaTime;

        this.transform.position = new Vector2((float)x, (float)y);
    }
}
