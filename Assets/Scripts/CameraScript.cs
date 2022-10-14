using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    public Transform player;

    void Update()
    {   
        if (player.transform.position.x == transform.position.x + 2)
        {
            transform.position = player.transform.position + new Vector3(2, 1);
        }
        
    }
}
