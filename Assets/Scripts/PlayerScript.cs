using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerScript : MonoBehaviour
{    
    private Rigidbody2D rb2D;
    private Boolean canJump = false; 
    private int health;
    private Vector3 startingPos = new Vector3(0f, 0f);
    private float lastTime;
    private int numOfJumps = 2;
    public float moveSpeed = 0.1f;
    public float jumpHeight = 400f;
    

    void Awake() 
    {  
        rb2D = gameObject.AddComponent<Rigidbody2D>();
        rb2D.freezeRotation = true;

        gameObject.AddComponent<BoxCollider2D>();

        health = 5;

        lastTime = Time.time - 0.5f;
        
    } 
   
    void FixedUpdate()
    {           
        if (Input.GetKey(KeyCode.Space) & (Time.time - lastTime > 0.5f))
        {   
            if (canJump | numOfJumps == 1)
            {
                rb2D.AddForce(transform.up * jumpHeight);
                lastTime = Time.time;
                numOfJumps -= 1;
            }

            
        } 

        
        if (Input.GetKey(KeyCode.RightArrow))
        {   
            if (Input.GetKey(KeyCode.LeftShift))
            {
                transform.position += new Vector3(moveSpeed*1.6f, 0);
            }
            else
            {
                transform.position += new Vector3(moveSpeed, 0);
            }
            
            
        } 
        else if (Input.GetKey(KeyCode.LeftArrow))
        {   
            if (Input.GetKey(KeyCode.LeftShift))
            {
                transform.position += new Vector3(-1f*moveSpeed*1.6f, 0);
            }
            else
            {
                transform.position += new Vector3(-1f*moveSpeed, 0);
            }
            
        }
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Climbable")
        {   
            canJump = true;
            numOfJumps = 2;
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
        if (col.gameObject.tag == "Climbable")
        {
            canJump= true;

            if (Input.GetKey(KeyCode.Space))
            {
                canJump = false;
            }
        }
    }

}

