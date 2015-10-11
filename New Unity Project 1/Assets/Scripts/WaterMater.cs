using System;
using UnityEngine;
using System.Collections;

public class WaterMater : MonoBehaviour
{
    private double minPos = -6.064596;
    public static float Water = 0;
    private float coef = 4.9f / 24;
    private Vector3 point;
    void Update()
    {
        if (Water > 0)
        {
            Water -= 0.0005f;
            point = new Vector3((float)(minPos + (Water * coef)), transform.position.y, transform.position.z);
            gameObject.transform.position = point;

        }
    }
}
