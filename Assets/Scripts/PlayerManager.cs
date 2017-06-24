using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour {

    public GameObject player;
    private static SpriteRenderer faceDirection;
    public float speed = 10.0F;
    public float rotationSpeed = 100.0F;
    void Update()
    {
        faceDirection = player.GetComponent<SpriteRenderer>();
        float translation = Input.GetAxis("Horizontal") * speed;
        translation *= Time.deltaTime;
        transform.Translate(translation, 0, 0);
        if(translation < 0)
        {
            faceDirection.flipX = false;
        }
        if(translation > 0)
        {
            faceDirection.flipX = true;
        }

    }
}
