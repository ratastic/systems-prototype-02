using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerMove : MonoBehaviour
{
    private Rigidbody2D rb;
    public int moveSpeed;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetAxisRaw("Horizontal"))
        {
            rb.linearVelocity = new Vector2(moveSpeed, 0);
        }

        if (Input.GetKey(KeyCode.Space))
        {
            rb.linearVelocity = new Vector2(0, moveSpeed);
        }
    }
}
