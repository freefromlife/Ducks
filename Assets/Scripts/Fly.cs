﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fly : MonoBehaviour
{
    [SerializeField]
    public GameObject hunter;
    [SerializeField]
    public GameObject OutOfScreenSpot;
    [SerializeField]
    private SpriteRenderer mySpriteRenderer;
    [SerializeField]
    private Animator myAnimator;
    [SerializeField]
    private Rigidbody2D myRigit;
    [SerializeField]
    public GameObject SC;
    public float speed;
    public float Score = 1;
    public GameObject destination;
    private bool alive = true;



    // Use this for initialization
    void Start()
    {
        destination = hunter;
    }

    // Update is called once per frame
    void Update()
    {
        FlyToSpot(destination);

    }
    void OnTriggerEnter2D(Collider2D coll)
    { if (coll.tag == "Bullet")
        {
            alive = false;
            myAnimator.Play("Die");
            myRigit.gravityScale = 2;
            Destroy(gameObject, 5);
            SC.GetComponent<ScoreCounter>().TakeScore(Score * Mathf.RoundToInt(speed));
        }
        if (coll.tag == "Ballon" && alive == true)
        {
            destination = OutOfScreenSpot;
            myAnimator.Play("FlyDown");
            Destroy(gameObject, 10);
            speed++;
            coll.GetComponent<BallonHealth>().MinusBag();

        }
        
    }
    public void FlyToSpot( GameObject spot)
    {
        var delta = transform.position - spot.transform.position;
        delta.Normalize();
        float moveSpeed = speed * Time.deltaTime;
        transform.position = transform.position - (delta* moveSpeed);
        if (transform.position.x > spot.transform.position.x)
        {
            mySpriteRenderer.flipX = true;
        }
        if (transform.position.x<spot.transform.position.x)
        {
            mySpriteRenderer.flipX = false;
        }
     }
}
