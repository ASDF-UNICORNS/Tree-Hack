using UnityEngine;
using System.Collections;

public class ChangeNightAndDay : MonoBehaviour
{
    public static bool Dragging;
    public static string WhatWasDragging = "";
    private bool swap;
    public SpriteRenderer Background;
    private Vector3 point;
    public Sprite DayTexture;
    public Sprite NightTexture;
	void Update () {

        point = Camera.main.ScreenToWorldPoint(Input.mousePosition);
	    if ((point.x <= transform.position.x + 1.6 && point.x >= transform.position.x - 1.6) &&
	        (point.y <= transform.position.y + 1.1 && point.y >= transform.position.y - 1.1) &&
	        (Input.GetMouseButtonDown(0)))
            {
                swap = !swap;
                if (swap)
                {
                    Background.sprite = DayTexture;
                    SunMoonSwapAndAnimatio.SunOrMoon = true;
                }
                else
                {
                    Background.sprite = NightTexture;
                    SunMoonSwapAndAnimatio.SunOrMoon = false;
                }
            }
	    Dragging = false;
	}
}
