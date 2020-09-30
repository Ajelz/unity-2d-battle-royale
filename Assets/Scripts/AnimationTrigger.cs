using Boo.Lang.Environments;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class AnimationTrigger : MonoBehaviour
{

    Transform myRigidParent;
    Transform myBoxParent;
    Rigidbody2D myRigid;
    BoxCollider2D myBox;
    Animator myOldAnimator;
    // Start is called before the first frame update
    void Start()
    {
        myRigid = GetComponent<Rigidbody2D>();
        myOldAnimator = GetComponent<Animator>();
        myBox = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        myRigidParent = transform.parent;
        myRigid = myRigidParent.GetComponent<Rigidbody2D>();
        myBoxParent = transform.parent;
        myBox = myBoxParent.GetComponent<BoxCollider2D>();
        RunCheck();
        JumpCheck();
        ClimbCheck();
        Crouch();
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
        if (CrossPlatformInputManager.GetButtonDown("left shift"))
        {
            myOldAnimator.SetBool("Crouch", true);
            print("shifting");
        }
        if (CrossPlatformInputManager.GetButtonUp("left shift"))
        {
            myOldAnimator.SetBool("Crouch", false);
        }
    }
    void JumpCheck()
    {
        if (!myBox.IsTouchingLayers(LayerMask.GetMask("Ground")))
        {
            myOldAnimator.SetBool("Jump", true);
        }
        else myOldAnimator.SetBool("Jump", false);
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
