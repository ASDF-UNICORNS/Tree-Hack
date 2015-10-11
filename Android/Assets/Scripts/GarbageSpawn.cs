using UnityEngine;
using System;
using System.Collections;
using System.Security.Policy;

public class GarbageSpawn : MonoBehaviour
{
    public Sprite GarbageSprite1;
    public Sprite GarbageSprite2;
    public Sprite GarbageSprite3;
    public Sprite GarbageSprite4;
    public Sprite GarbageSprite5;
    public Sprite GarbageSprite6;
    public GameObject Garbage;
    public SpriteRenderer GarbageRender;
    private int delay;
    void Update()
    {
        if (delay == 500)
        {
            var rand = new System.Random();
            int xPos = rand.Next(0, 20) - 12;
            float yPos = rand.Next(1, 10) - 9.5f;
            int choseSprite = rand.Next(1, 7);
            int rotation = rand.Next(1, 361);
            switch (choseSprite)
            {
                case 1:
                    GarbageRender.sprite = GarbageSprite1;
                    break;
                case 2:
                    GarbageRender.sprite = GarbageSprite2;
                    break;
                case 3:
                    GarbageRender.sprite = GarbageSprite3;
                    break;
                case 4:
                    GarbageRender.sprite = GarbageSprite4;
                    break;
                case 5:
                    GarbageRender.sprite = GarbageSprite5;
                    break;
                case 6:
                    GarbageRender.sprite = GarbageSprite6;
                    break;
            }
            Garbage.transform.Rotate(0,0,rotation);
            Instantiate(Garbage, new Vector3(xPos, yPos, 0), Quaternion.identity);
            delay = 0;
        }
        delay++;

    }
}
