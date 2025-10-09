using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class PlayerMove : MonoBehaviour
{
    private SpriteRenderer sr;
    private Rigidbody2D rb;
    public int moveSpeed;

    public bool isCementing = false;
    public bool isPlatformed = false;

    public Sprite walk1;
    public Sprite walk2;
    private bool isWalk = true;

    public Sprite drown1;
    public Sprite drown2;
    private bool isDrown = false;

    public GameObject sugar;
    public GameObject replay;

    public AudioSource crunch;
    public bool isAlive = true;
    public GameObject youDied;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();

        sugar.SetActive(true);
        replay.SetActive(false);
        youDied.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (isAlive == true)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {   
                if (isCementing == true)
                {
                    rb.linearVelocity = new Vector2(moveSpeed, moveSpeed);
                    isDrown = true;
                    if (isDrown == true)
                    {
                        sr.sprite = drown2;
                    }
                    else
                    {
                        sr.sprite = drown1;
                    }

                    isDrown = !isDrown;
                } 
                else if (isPlatformed == true)
                {
                    rb.linearVelocity = new Vector2(moveSpeed, 0);

                    if (isWalk)
                    {
                        sr.sprite = walk2;
                    }
                    else
                    {
                        sr.sprite = walk1;
                    }

                    isWalk = !isWalk;
                }
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

        if (col.gameObject.CompareTag("sugar"))
        {
            sugar.SetActive(false);
            replay.SetActive(true);
            crunch.Play();
        }

        if (col.gameObject.CompareTag("floor"))
        {
            isAlive = false;
            replay.SetActive(true);
            youDied.SetActive(true);
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

    public void ReplayScene()
    {
        SceneManager.LoadScene("SampleScene");
    }

}