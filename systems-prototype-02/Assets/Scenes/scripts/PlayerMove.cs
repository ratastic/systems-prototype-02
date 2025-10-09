using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerMove : MonoBehaviour
{
    private Rigidbody2D rb;
    public int moveSpeed;

    public bool isCementing = false;
    public bool isPlatformed = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (isCementing == true)
            {
                rb.linearVelocity = new Vector2(moveSpeed, moveSpeed);
            } 
            else if (isPlatformed == true)
            {
                rb.linearVelocity = new Vector2(moveSpeed, 0);
            }
        }
    }

    public void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("platform"))
        {
            isPlatformed = true;
            Debug.Log ("touching platform");
        }
    }

    public void OnCollisionExit2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("platform"))
        {
            isPlatformed = false;
            Debug.Log ("not touching platform");
        }
    }

    public void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("cement"))
        {
            isCementing = true;
            Debug.Log ("touching cement");
        }
    }

    public void OnTriggerExit2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("cement"))
        {
            isCementing = false;
            Debug.Log ("not touching cement");
        }
    }

}