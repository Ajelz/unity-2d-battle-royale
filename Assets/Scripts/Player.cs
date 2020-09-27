using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets;
using UnityStandardAssets.CrossPlatformInput;

public class Player : MonoBehaviour
{

    // 1. Config - always put config (anything to do with before starting playing)
    [SerializeField] float runSpeed = 8f;
    [SerializeField] float jumpForce = 20f;
    [SerializeField] float climbSpeed = 8f;

    //2. State -  
    // bool isAlive = true;                 /* commenting this because it makes a warning */

    //3. Cache component references
    Rigidbody2D myRigidBody;
    Animator myAnimator;
    PolygonCollider2D myBody2D;
    BoxCollider2D myFeet;
    float gravityScaleAtStart;

    // Messages then methods
    void Start()
    {
        myRigidBody = GetComponent<Rigidbody2D>();
        myAnimator = GetComponent<Animator>();
        myBody2D = GetComponent<PolygonCollider2D>();
        myFeet = GetComponent<BoxCollider2D>();
        gravityScaleAtStart = myRigidBody.gravityScale;
    }

    // Update is called once per frame
    void Update()
    {
        Run();
        Jump();
        ClimbLadder();
        // FlipSprite();
    }

    private void Run()
    {
        float controlThrow = CrossPlatformInputManager.GetAxis("Horizontal"); // the value can be from -1 to 1
        Vector2 playerVelocity = new Vector2(controlThrow * runSpeed, myRigidBody.velocity.y);
        myRigidBody.velocity = playerVelocity;


        // bool playerHasHorizontalSpeed = Mathf.Abs(myRigidBody.velocity.x) > Mathf.Epsilon;
        // if (playerHasHorizontalSpeed) // To run the running animation
        // {
        //     myAnimator.SetBool("Running", playerHasHorizontalSpeed); //playerHasHorizontalSpeed will either be true or false, therefore triggering the animation
        // }
    }

    private void ClimbLadder()
    {
        if (!myBody2D.IsTouchingLayers(LayerMask.GetMask("Climbing")))
        {
            myRigidBody.gravityScale = gravityScaleAtStart;
            return;
        }

        float controlThrow = CrossPlatformInputManager.GetAxis("Vertical");
        Vector2 climbVelocity = new Vector2(myRigidBody.velocity.x, controlThrow * climbSpeed);
        myRigidBody.velocity = climbVelocity;
        myRigidBody.gravityScale = 0f;
    }

    private void Jump()
    {
        if(!myFeet.IsTouchingLayers(LayerMask.GetMask("Ground"))) { return; }

        if (CrossPlatformInputManager.GetButtonDown("Jump")) {
            Vector2 jumpVelocityToAdd = new Vector2(0f, jumpForce);
            myRigidBody.velocity += jumpVelocityToAdd;
            print("Jumping");
        }
    }

    // private void FlipSprite()
    // {
    //     bool playerHasHorizontalSpeed = Mathf.Abs(myRigidBody.velocity.x) > Mathf.Epsilon;
    //     if (playerHasHorizontalSpeed)
    //     {
    //         transform.localScale = new Vector2(Mathf.Sign(myRigidBody.velocity.x), 1f);
    //     }
    // }
}
