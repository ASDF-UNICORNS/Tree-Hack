using System.Security.Cryptography.X509Certificates;
using UnityEngine;
using Assets.Scripts;

public class DragAndDropPlusRain : MonoBehaviour
{

    public GameObject drop;
    private Vector3 point;
    private Vector3 defaultPosition;
    private bool wasPressed;
    private bool wasDragging;
    private int timeout;
    private void Start()
    {
        defaultPosition = transform.position;
    }

    private void Update()
    {
        point = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        if (!ChangeNightAndDay.Dragging && (ChangeNightAndDay.WhatWasDragging == "rain" || ChangeNightAndDay.WhatWasDragging == ""))
        {
            if (Input.GetMouseButton(0) && wasDragging)
            {
                point.z = transform.position.z;
                transform.position = point;
                wasDragging = true;
                if (transform.position.x < 9)
                {
                    Rain();
                    WaterMater.Water += 0.01f;
                }

                ChangeNightAndDay.Dragging = true;
                ChangeNightAndDay.WhatWasDragging = "rain";


            }
            else if ((point.x <= transform.position.x + 1.6 && point.x >= transform.position.x - 1.6) &&
                (point.y <= transform.position.y + 1.1 && point.y >= transform.position.y - 1.1) &&
                (Input.GetMouseButton(0)))
            {
                point.z = transform.position.z;
                transform.position = point;
                wasDragging = true;
                if (transform.position.x < 9)
                {
                    Rain();
                    WaterMater.Water += 0.01f;
                }

                ChangeNightAndDay.Dragging = true;
                ChangeNightAndDay.WhatWasDragging = "rain";

            }
            else
            {
                if (ChangeNightAndDay.WhatWasDragging == "rain")
                {
                    ChangeNightAndDay.WhatWasDragging = "";

                }
                wasDragging = false;
                transform.position = defaultPosition;

            }
        }

    }
    public void Rain()
    {
        if (timeout >= 6)
        {
            var rand = new System.Random();
            int pos = rand.Next(0, 3);
            switch (pos)
            {
                case 0:
                    Instantiate(drop,
                        new Vector3(transform.position.x, transform.position.y - 0.5f, transform.position.z),
                        Quaternion.identity);
                    break;
                case 1:
                    Instantiate(drop,
                        new Vector3(transform.position.x + 0.5f, transform.position.y - 0.5f, transform.position.z),
                        Quaternion.identity);
                    break;
                case 2:
                    Instantiate(drop,
                        new Vector3(transform.position.x - 0.5f, transform.position.y - 0.5f, transform.position.z),
                        Quaternion.identity);
                    break;
            }
            timeout = 0;
        }
        timeout++;
    }
}
