using Assets.HeroEditor.Common.CharacterScripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets;
using UnityStandardAssets.CrossPlatformInput;

public class OldPlayer : MonoBehaviour
{

    // 1. Config - always put config (anything to do with before starting playing)
    [SerializeField] float runSpeed = 8f;
    [SerializeField] float jumpForce = 20f;
    [SerializeField] float climbSpeed = 8f;
    [SerializeField] float crouchSpeed = 4f;
    [SerializeField] bool isCrouch = false;

    //2. State -  
    bool isAlive = true;

    //3. Cache component references
    Rigidbody2D myOldRigidBody;
    BoxCollider2D myOldFeet;
    float gravityScaleAtStart;

    // Messages then methods
    void Awake()
    {
        myOldRigidBody = GetComponent<Rigidbody2D>();
        myOldFeet = GetComponent<BoxCollider2D>();
        gravityScaleAtStart = myOldRigidBody.gravityScale;
    }

    void Update()
    {
        if (isAlive)
        {
            Run();
            Jump();
            ClimbLadder();
            Crouch();
        }
        else
        {
            Destroy(gameObject.GetComponent<PolygonCollider2D>());
            Destroy(gameObject.GetComponentInChildren<FirearmFire>());
            //Destroy(gameObject, 1f); // OPTIONAL
        }

        // FlipSprite();
    }

    public bool isPlayerAlive()
    {
        return isAlive;
    }

    private void Crouch()
    {
        if (CrossPlatformInputManager.GetButtonDown("left shift"))
        {
            isCrouch = true;
        }
        if (CrossPlatformInputManager.GetButtonUp("left shift"))
        {
            isCrouch = false;
        }


    }


    private void Run()
    {
        Vector2 playerVelocity = new Vector2(myOldRigidBody.velocity.x, myOldRigidBody.velocity.y);
        float controlThrow = 0f;
        controlThrow = CrossPlatformInputManager.GetAxis("Horizontal"); // the value can be from -1 to 1
        if (!isCrouch)
        {
            playerVelocity = new Vector2(controlThrow * runSpeed, myOldRigidBody.velocity.y);
            myOldRigidBody.velocity = playerVelocity;
        } else
        {
            playerVelocity = new Vector2(controlThrow * crouchSpeed, myOldRigidBody.velocity.y);
            myOldRigidBody.velocity = playerVelocity;
        }

    }

    private void ClimbLadder()
    {
        if (!myOldFeet.IsTouchingLayers(LayerMask.GetMask("Climb")))
        {
            myOldRigidBody.gravityScale = gravityScaleAtStart;
            return;
        }

        float controlThrow = CrossPlatformInputManager.GetAxis("Vertical");
        Vector2 climbVelocity = new Vector2(myOldRigidBody.velocity.x, controlThrow * climbSpeed);
        myOldRigidBody.velocity = climbVelocity;
        myOldRigidBody.gravityScale = 0f;

    }

    private void Jump()
    {
        if (!myOldFeet.IsTouchingLayers(LayerMask.GetMask("Ground")))
        { 
            if (myOldFeet.IsTouchingLayers(LayerMask.GetMask("Player")))
            {
                if (CrossPlatformInputManager.GetButtonDown("Jump"))
                {
                    Vector2 jumpVelocityToAdd = new Vector2(0f, jumpForce);
                    myOldRigidBody.velocity += jumpVelocityToAdd;
                }
            }
            return;
        }



        if (CrossPlatformInputManager.GetButtonDown("Jump")) {
            Vector2 jumpVelocityToAdd = new Vector2(0f, jumpForce);
            myOldRigidBody.velocity += jumpVelocityToAdd;
        }
    }

    public void setIsAlive(bool alive)
    {
        if (alive)
        {
            isAlive = true;
        }
        else
        {
            isAlive = false;
        }
    }

    //  private void FlipSprite()
    //  {
    //      bool playerHasHorizontalSpeed = Mathf.Abs(myOldRigidBody.velocity.x) > Mathf.Epsilon;
    //      if (playerHasHorizontalSpeed)
    //      {
    //          transform.localScale = new Vector2(Mathf.Sign(myOldRigidBody.velocity.x), 1f);
    //      }
    //  }
}
