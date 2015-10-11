using UnityEngine;
using System.Collections;

public class DragAndDropFertilizer : MonoBehaviour
{
    private Vector3 defaultPosition;
    private Vector3 point;
    private bool wasDragging;
    private void Start()
    {
        defaultPosition = transform.position;
    }

    private void Update()
    {
        point = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        if (!ChangeNightAndDay.Dragging && (ChangeNightAndDay.WhatWasDragging == "fr" || ChangeNightAndDay.WhatWasDragging == ""))
        {
            if (Input.GetMouseButton(0) && wasDragging)
            {
                point.z = transform.position.z;
                transform.position = point;
                wasDragging = true;
                ChangeNightAndDay.Dragging = true;
                ChangeNightAndDay.WhatWasDragging = "fr";
            }
            else if ((point.x <= transform.position.x + 1.6 && point.x >= transform.position.x - 1.6) &&
                (point.y <= transform.position.y + 1.1 && point.y >= transform.position.y - 1.1) &&
                (Input.GetMouseButton(0)))
            {
                point.z = transform.position.z;
                transform.position = point;
                wasDragging = true;
                ChangeNightAndDay.Dragging = true;
                ChangeNightAndDay.WhatWasDragging = "fr";


            }
            else
            {
                if (ChangeNightAndDay.WhatWasDragging == "fr")
                {
                    ChangeNightAndDay.WhatWasDragging = "";
                }
                wasDragging = false;
                transform.position = defaultPosition;

            }
        }

    }

}
