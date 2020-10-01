using Boo.Lang.Environments;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class AnimationTrigger : MonoBehaviour
{

    Transform myRigidParent;
    Transform myBoxParent;
    Transform myTestBarParent;
    TestBar myTestBar;
    Rigidbody2D myRigid;
    BoxCollider2D myBox;
    Animator myOldAnimator;
    // Start is called before the first frame update
    void Start()
    {
        myTestBar = GetComponent<TestBar>();
        myRigid = GetComponent<Rigidbody2D>();
        myOldAnimator = GetComponent<Animator>();
        myBox = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        myTestBarParent = transform.parent;
        myTestBar = myTestBarParent.GetComponent<TestBar>();
        myRigidParent = transform.parent;
        myRigid = myRigidParent.GetComponent<Rigidbody2D>();
        myBoxParent = transform.parent;
        myBox = myBoxParent.GetComponent<BoxCollider2D>();
        RunCheck();
        JumpCheck();
        ClimbCheck();
        Crouch();
        LifeCheck();
    }

    public void LifeCheck()
    {
        bool isAlive = myTestBar.LifeStatus();
        int random = Random.Range(0, 2);
        if (!isAlive)
        {
            if (random == 0)
                myOldAnimator.SetBool("DieBack", true);
            else if (random == 1)
                myOldAnimator.SetBool("DieFront", true);
        }
        else
        {
            myOldAnimator.SetBool("DieBack", false);
            myOldAnimator.SetBool("DieFront", false);
        }
    }
    void RunCheck()
    {
        bool playerHasHorizontalSpeed = Mathf.Abs(myRigid.velocity.x) > 1;
        if (playerHasHorizontalSpeed) // To run the running animation
        {
            myOldAnimator.SetBool("Run", true); //playerHasHorizontalSpeed will either be true or false, therefore triggering the animation
        }
        else myOldAnimator.SetBool("Run", false);
    }

    void Crouch()
    {
        bool playerHasHorizontalSpeed = Mathf.Abs(myRigid.velocity.x) > 1;
        if (playerHasHorizontalSpeed)
        {
            myOldAnimator.SetBool("Crouch", false);
        }
        if (CrossPlatformInputManager.GetButtonDown("left shift"))
        {
            myOldAnimator.SetBool("Crouch", true);
            print("shifting");
        }
        else if (CrossPlatformInputManager.GetButtonUp("left shift"))
        {
            myOldAnimator.SetBool("Crouch", false);
        }

    }
    void JumpCheck()
    {
        bool playerHasHorizontalSpeed = Mathf.Abs(myRigid.velocity.x) > 0;
        if (!playerHasHorizontalSpeed)
        {
            if (!myBox.IsTouchingLayers(LayerMask.GetMask("Ground")))
            {
                myOldAnimator.SetBool("Jump", true);
            }
            else myOldAnimator.SetBool("Jump", false);
        }
        else
            myOldAnimator.SetBool("Jump", false);
    }
    private void ClimbCheck()
    {
        if (!myBox.IsTouchingLayers(LayerMask.GetMask("Climb")))
        {
            myOldAnimator.SetBool("Climb", false);
            return;
        }
        bool playerHasVerticalSpeed = Mathf.Abs(myRigid.velocity.y) > Mathf.Epsilon;
        myOldAnimator.SetBool("Climb", playerHasVerticalSpeed);
    }
}
