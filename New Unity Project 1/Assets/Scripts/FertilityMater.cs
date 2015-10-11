using UnityEngine;
using System.Collections;

public class FertilityMater : MonoBehaviour
{
    private double minPos = -11.5646;
    public double Fertility = 0;
    private double coef = 4.9 / 10;
    private Vector3 point;
    void Update()
    {
        if (Fertility > 0)
        {
            Fertility -= 0.001f;
            point = new Vector3((float)(minPos + (Fertility * coef)), transform.position.y, transform.position.z);
            gameObject.transform.position = point;

        }
    }
}
