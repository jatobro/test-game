using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerScript : MonoBehaviour
{    
    Rigidbody2D rb2D;
    Boolean isGrounded = false; 
    int health;
    Vector3 startingPos = new Vector3(0f, 0f);
    void Awake() 
    {  
        rb2D = gameObject.AddComponent<Rigidbody2D>();
        rb2D.freezeRotation = true;

        gameObject.AddComponent<BoxCollider2D>();

        health = 5;

        
    } 
   
    void FixedUpdate()
    {           
        if (Input.GetKey(KeyCode.Space) & isGrounded)
        {   
            rb2D.AddForce(transform.up * 400);
        }

        
        if (Input.GetKey(KeyCode.RightArrow))
        {   
            if (Input.GetKey(KeyCode.LeftShift))
            {
                transform.position += new Vector3(0.16f, 0);
            }
            else
            {
                transform.position += new Vector3(0.1f, 0);
            }
            
            
        } 
        else if (Input.GetKey(KeyCode.LeftArrow))
        {   
            if (Input.GetKey(KeyCode.LeftShift))
            {
                transform.position += new Vector3(-0.16f, 0);
            }
            else
            {
                transform.position += new Vector3(-0.1f, 0);
            }
            
        }
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Ground")
        {   
            isGrounded = true;
        } 

        if (col.gameObject.tag == "Enemy")
        {
            health -= 1;

            if (health == 0)
            {
                Destroy(gameObject);
            }
            else
            {
                transform.position = startingPos;
            }
        }
    }

    void OnCollisionStay2D(Collision2D col)
    {
        if (col.gameObject.tag == "Ground")
        {
            isGrounded = true;

            if (Input.GetKey(KeyCode.Space))
            {
                isGrounded = false;
            }
        }
    }

}

