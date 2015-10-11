using UnityEngine;
using System.Collections;
using System.Threading;

public class SunMoonSwapAndAnimatio : MonoBehaviour
{
    public static bool SunOrMoon = true;
    public Sprite Sun1;
    public Sprite Sun2;
    public Sprite Sun3;
    public Sprite Sun4;
    public Sprite Moon1;
    public Sprite Moon2;
    public Sprite Moon3;
    public Sprite Moon4;
    public Sprite Moon5;
    public Sprite Moon6;
    public Sprite Moon7;
    public Sprite Moon8;
    private int SunSprite;
    private int MoonSprite;
    public SpriteRenderer Sprite;
    private int sunPos = 0;
    private int moonPos = 0;
    private int delay = 0;

    private void Update()
    {
        Thread.Sleep(10);
        if (delay == 4)
        {
            if (SunOrMoon)
            {
                switch (sunPos)
                {
                    case 0:
                        Sprite.sprite = Sun1;
                        break;
                    case 1:
                        Sprite.sprite = Sun2;
                        break;
                    case 2:
                        Sprite.sprite = Sun3;
                        break;
                    case 3:
                        Sprite.sprite = Sun4;
                        break;
                }
                if (sunPos == 3)
                {
                    sunPos = 0;
                }
                else sunPos++;
            }
            else
            {
                switch (moonPos)
                {
                    case 0:
                        Sprite.sprite = Moon1;
                        break;
                    case 1:
                        Sprite.sprite = Moon2;
                        break;
                    case 2:
                        Sprite.sprite = Moon3;
                        break;
                    case 3:
                        Sprite.sprite = Moon4;
                        break;
                    case 4:
                        Sprite.sprite = Moon5;
                        break;
                    case 5:
                        Sprite.sprite = Moon6;
                        break;
                    case 6:
                        Sprite.sprite = Moon7;
                        break;
                    case 7:
                        Sprite.sprite = Moon8;
                        break;
                }
                if (moonPos == 7)
                {
                    moonPos = 0;
                }
                else
                    moonPos++;
            }
            delay = 0;
        }
        delay++;
    }
}