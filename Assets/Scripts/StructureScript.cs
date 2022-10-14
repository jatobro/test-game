using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StructureScript : MonoBehaviour
{   

    void Awake()
    {   
        gameObject.AddComponent<BoxCollider2D>();
    }

}
