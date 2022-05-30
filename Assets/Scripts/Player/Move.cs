using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    [SerializeField] float runSpeed = 4;
    [SerializeField] SpriteRenderer bodySprite;
    [SerializeField] bool startPlay = false;

    Rigidbody2D myRigidBody;
    bool playerHasLeftSpeed;
    bool playerHasRightSpeed;
    
    void Awake()
    {
        myRigidBody = GetComponent<Rigidbody2D>();
    }


    void Update()
    {
        if (startPlay)
        {
            MovePlayer();
        }
    }

    private void MovePlayer()
    {
        float controlThrowX = Input.GetAxisRaw("Horizontal"); //value is between -1 to +1
        float controlThrowY = Input.GetAxisRaw("Vertical");
        Vector2 playerVelocity = new Vector2(controlThrowX * runSpeed, controlThrowY * runSpeed);
        myRigidBody.velocity = playerVelocity;


        playerHasLeftSpeed = (myRigidBody.velocity.x) < 0f;
        playerHasRightSpeed = (myRigidBody.velocity.x) > 0f;

        FlipPlayer();
    }

    private void FlipPlayer()
    {
        bool playerHasHorizontalSpeed = Mathf.Abs(myRigidBody.velocity.x) > Mathf.Epsilon;
        if (playerHasHorizontalSpeed)
        {
            transform.localScale = new Vector2(Mathf.Sign(-myRigidBody.velocity.x), 1f);
        }
    }

    public void StartPlay()
    {
        startPlay = true;
    }
}
