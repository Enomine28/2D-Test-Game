using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdSpawnManager : MonoBehaviour
{
    private float randY;
    public float spawnRate = 2f;
    float nextSpawn = 0.0f;
    public GameObject budgie;
    private static Vector3 newBirdPosi;
    private static GameObject newBird;
    private static GameObject[] birds;
    // Use this for initialization
    void Start()
    {

    }
    // Update is called once per frame
    void Update()
    {
        MoveSpawned();        
        if (Time.time > nextSpawn)
        {
            nextSpawn = Time.time + spawnRate;            
            CloneBird();
        }        
    }

    private void CloneBird()
    {
        newBirdPosi = RandomizeTransformSpawn();
        newBird = Instantiate(budgie, newBirdPosi, Quaternion.identity);
    }
    private Vector3 RandomizeTransformSpawn()
    {
        randY = Random.Range(-1, 4);
        newBirdPosi = new Vector3(-7f, randY, 0f);
        return newBirdPosi;
    }

    private static void MoveSpawned()
    {
        birds = GameObject.FindGameObjectsWithTag("Birdie");
        if (birds != null)
        {
            foreach (GameObject birdie in birds)
            {
                float birdPosiX = birdie.transform.position.x;
                float birdPosiY = birdie.transform.position.y;
                float birdPosY = RandomizeY(birdPosiY);
                float randomSpeed = RandomizeSpeed();
                if (birdPosiX > 8.5f)
                {
                    Destroy(birdie);
                }                
                if (birdPosiX < 8.5f)
                {
                    birdie.transform.position = new Vector3(birdPosiX += randomSpeed, birdPosY, 0f);
                }                    
            }
        }
    }
    private static float RandomizeSpeed()
    {
        float newSpeed = Random.Range(0.02f, 0.05f);
        return newSpeed;
    }
    static float RandomizeY(float birdPosiY)
    {
        int temp = UnityEngine.Random.Range(0, 200);
        if (temp >= 0 && temp <= 25 || temp >= 50 && temp <= 75 || temp >= 100 && temp <= 125 || temp >= 150 && temp <= 175)
        {//hoch
            if (birdPosiY >= 4.0f)
            {
                return birdPosiY;
            }
            if (birdPosiY >= 0.0f && birdPosiY <= 4.8f)
            {
                birdPosiY += 0.01f;
                return birdPosiY;
            }
        }
        else
        {//runter
            if (birdPosiY <= 0.0f)
            {
                return birdPosiY;
            }
            if (birdPosiY >= 0.0f && birdPosiY <= 4.8f)
            {
                birdPosiY -= 0.01f;
                return birdPosiY;
            }
        }
        return birdPosiY;
    }
}
