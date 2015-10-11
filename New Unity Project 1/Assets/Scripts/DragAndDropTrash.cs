using UnityEngine;
using System.Collections;

public class DragAndDropTrash : MonoBehaviour
{
    private Vector3 point;
    private bool wasDragging;
	void Update () {
        point = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        if (!ChangeNightAndDay.Dragging && (ChangeNightAndDay.WhatWasDragging == "tr" || ChangeNightAndDay.WhatWasDragging == ""))
        {
            if (Input.GetMouseButton(0) && wasDragging)
            {
                point.z = transform.position.z;
                transform.position = point;
                wasDragging = true;
                ChangeNightAndDay.Dragging = true;
                ChangeNightAndDay.WhatWasDragging = "tr";
            }
            else if ((point.x <= transform.position.x + 1.6 && point.x >= transform.position.x - 1.6) &&
                (point.y <= transform.position.y + 1.1 && point.y >= transform.position.y - 1.1) &&
                (Input.GetMouseButton(0)))
            {
                point.z = transform.position.z;
                transform.position = point;
                wasDragging = true;
                ChangeNightAndDay.Dragging = true;
                ChangeNightAndDay.WhatWasDragging = "tr";


            }
            else
            {
                if (ChangeNightAndDay.WhatWasDragging == "tr")
                {
                    ChangeNightAndDay.WhatWasDragging = "";
                }
                wasDragging = false;

            }
        }
	}
}
