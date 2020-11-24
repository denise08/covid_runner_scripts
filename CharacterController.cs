﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class CharacterController : MonoBehaviour
{
    //character movement
    public int speed = 5;
    public Rigidbody2D rb;
    public int jumpForce = 7; 
    private bool facingRight = true;

    //check if player is on ground
    [SerializeField]
    public bool isGroundedRoad;
    public bool isGroundedBlock;

    //ground layers/checks
    public Transform groundCheckOrigin;
    public float checkRadius = .2f;
    public LayerMask groundLayer;
    public LayerMask platformLayer;

    public Animator animator;

    //game over objects
    public GameObject gameOverText, restartButton;

    //finish game objects
    public GameObject winText, playAgainButton;


    //display mask count
    public float numMasks = 0;
    public TextMeshProUGUI maskCount;

    //slow down collection/damage to ensure properly incremented variables
    int waitTime;
    bool collected = false;
    bool damaged = false;

    //stats
    public TextMeshProUGUI itemCount;

    // Start is called before the first frame update
    void Start()
    {

        //game over stuff
        gameOverText.SetActive(false);
        restartButton.SetActive(false);

        //win game stuff
        winText.SetActive(false);
        playAgainButton.SetActive(false);

        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        isGroundedRoad = Physics2D.OverlapCircle(groundCheckOrigin.position, checkRadius, groundLayer);
        isGroundedBlock = Physics2D.OverlapCircle(groundCheckOrigin.position, checkRadius, platformLayer);

        if ((isGroundedRoad || isGroundedBlock) && Input.GetButtonDown("Jump"))
        {
            rb.velocity = Vector2.up * jumpForce;
        } 
        

    }

    private void FixedUpdate()
    {
        float x_dir = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(x_dir * speed, rb.velocity.y);

        animator.SetFloat("Speed", Mathf.Abs(x_dir));

        if(facingRight && x_dir < 0)
        {
            Flip();
        } else if(!facingRight && x_dir > 0)
        {
            Flip();
        }
    }

    private void Flip()
    {
        facingRight = !facingRight;
        var scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag.Equals("Virus") & !damaged)
        {
            if(numMasks == 0)
            {
                gameOverText.SetActive(true);
                restartButton.SetActive(true);
                gameObject.SetActive(false);
            } 
            else
            {
                damaged = true;
                numMasks--;
                maskCount.text = numMasks.ToString();
                StartCoroutine(damageWait());
            }
            
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //collecting shit
        if (collision.CompareTag("Mask") && !collected)
        {
            collected = true;
            print("collected mask");
            numMasks++;
            maskCount.text = numMasks.ToString();
            StartCoroutine(collectWait());
            Destroy(collision.gameObject);
        }

        //reach home
        if (collision.CompareTag("Finish"))
        {
            winText.SetActive(true);
            playAgainButton.SetActive(true);
            gameObject.SetActive(false);
        }

        //end of level 1
        if (collision.CompareTag("level1end"))
        {
            SceneManager.LoadScene(2);  //load stats at end of level 1
            Debug.Log(numMasks);
            itemCount.text = "Item Count: " + numMasks.ToString();
            
        }


    }

    IEnumerator collectWait()
    {
        waitTime = 1;
        Debug.Log("Waiting", gameObject);
        Debug.Log("ACTUALLY WAITING", gameObject);
        yield return new WaitForSeconds(waitTime);
        Debug.Log("Done Waiting", gameObject);
        collected = false;
        Debug.Log("ACTUALLY WAITING DONE", gameObject);
        Debug.Log("Done wit stuff", gameObject);
    }

    IEnumerator damageWait()
    {
        waitTime = 1;
        Debug.Log("Waiting", gameObject);
        Debug.Log("ACTUALLY WAITING", gameObject);
        yield return new WaitForSeconds(waitTime);
        Debug.Log("Done Waiting", gameObject);
        damaged = false;
        Debug.Log("ACTUALLY WAITING DONE", gameObject);
        Debug.Log("Done wit stuff", gameObject);
    }

}