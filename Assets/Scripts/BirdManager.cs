using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdManager : MonoBehaviour
{
    public GameObject trBird;
    public static SpriteRenderer rendBird;
    public static float birdPosX;
    public static float birdPosY;
    private static bool right = true;

    // Use this for initialization
    public void Start()
    {
        rendBird = GetComponent<SpriteRenderer>();
        birdPosX = trBird.transform.position.x;
        birdPosY = trBird.transform.position.y;
    }
    void Update()
    {
        MoveBirdie(trBird);        
    }
    public static void MoveBirdie(GameObject trBird)
    {
        RandomizeY();
        if (trBird.transform.position.x < 6.5f && right)
        {
            trBird.transform.position = new Vector3(birdPosX += 0.02f, birdPosY, 0f);
            if (trBird.transform.position.x >= 6.5f)
            {
                rendBird.flipX = true;
                right = false;
            }
        }
        if (trBird.transform.position.x >= -6.5f && !right)
        {
            trBird.transform.position = new Vector3(birdPosX -= 0.02f, birdPosY, 0f);
            if (trBird.transform.position.x <= -6.5f)
            {
                rendBird.flipX = false;
                right = true;
            }
        }
    }

    static void RandomizeY()
    {
        int temp = UnityEngine.Random.Range(0, 200);
        if (temp >= 0 && temp <= 25 || temp >= 50 && temp <= 75 || temp >= 100 && temp <= 125 || temp >= 150 && temp <= 175)
        {//hoch
            if (birdPosY >= 4.0f)
            {
                return;
            }
            if (birdPosY >= 0.0f && birdPosY <= 4.8f)
            {
                birdPosY += 0.01f;
            }
        }
        else
        {//runter
            if (birdPosY <= 0.0f)
            {
                return;
            }
            if (birdPosY >= 0.0f && birdPosY <= 4.8f)
            {
                birdPosY -= 0.01f;
            }
        }
    }

}
