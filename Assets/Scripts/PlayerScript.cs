using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerScript : MonoBehaviour
{    
    Rigidbody2D rb2D;
    Boolean IsGrounded = false; 
    void Awake() 
    {
        rb2D = gameObject.AddComponent<Rigidbody2D>();
        gameObject.AddComponent<BoxCollider2D>();

        rb2D.freezeRotation = true;
    } 
   
    void FixedUpdate()
    {           
        if (Input.GetKey(KeyCode.Space) & IsGrounded)
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
            IsGrounded = true;
        } 

        if (col.gameObject.tag == "Enemy")
        {
            Destroy(gameObject);
        }
    }

    void OnCollisionStay2D(Collision2D col)
    {
        if (col.gameObject.tag == "Ground")
        {
            IsGrounded = true;

            if (Input.GetKey(KeyCode.Space))
            {
                IsGrounded = false;
            }
        }
    }

}

