using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    public GameObject player;

    void Awake()
    {
        player = GameObject.Find("Player");
    }

    void FixedUpdate()
    {   
        if (player != null) 
        {
            if (player.transform.position.x > transform.position.x + 7.5f)
            {
                transform.position = transform.position + new Vector3(7.5f, 0f, 0f);
            }
            if (player.transform.position.x < transform.position.x - 7.5f) 
            {
                transform.position = transform.position + new Vector3(-7.5f, 0f, 0f);
            }


            if (player.transform.position.y > transform.position.y + 7.5f)
            {
                transform.position = transform.position + new Vector3(0f, 7.5f, 0f);
            }
            if (player.transform.position.y < transform.position.y - 7.5f) 
            {
                transform.position = transform.position + new Vector3(0f, -7.5f, 0f);
            }
        }
        
        
    }
}
