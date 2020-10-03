using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class NewPlayer : MonoBehaviour
{
    // 1. Config - always put config (anything to do with before starting playing)
    [SerializeField] float runSpeed = 20f;
    [SerializeField] float jumpForce = 35f;

    //2. State -  
    public bool isOnFloor = false;

    //3. Cache component references
    Rigidbody2D objectRigidbody2D;
    CapsuleCollider2D objectCapsuleCollider2D;
    BoxCollider2D objectBoxCollider2D;
    Animator objectAnimator;

    // Start is called before the first frame update
    void Start()
    {
        objectRigidbody2D = GetComponent<Rigidbody2D>();
        objectCapsuleCollider2D = GetComponent<CapsuleCollider2D>();
        objectBoxCollider2D = GetComponent<BoxCollider2D>();
        objectAnimator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        move();
        jump();
        objectFlip();
    }

    private void move(){
        float controlThrow = CrossPlatformInputManager.GetAxis("Horizontal");
        objectRigidbody2D.velocity = new Vector2(controlThrow * runSpeed, objectRigidbody2D.velocity.y);

        // for running animation
        if (CrossPlatformInputManager.GetButton("left")) objectAnimator.SetBool("isRunning", true);
        else if (CrossPlatformInputManager.GetButton("right")) objectAnimator.SetBool("isRunning", true);
        else objectAnimator.SetBool("isRunning", false);
    }

    private void jump(){
        if (CrossPlatformInputManager.GetButtonDown("Jump") && isOnFloor) {
            objectRigidbody2D.velocity += new Vector2(0f, jumpForce);
            isOnFloor = false;

            // for jumping animation
            objectAnimator.SetBool("isJumping", true);
        }
    }

    private void objectFlip(){
        if(objectRigidbody2D.velocity.x > 0) transform.eulerAngles = new Vector3(0, 0, 0);
        else if(objectRigidbody2D.velocity.x < 0) transform.eulerAngles = new Vector3(0, 180, 0);
    }

    private void OnCollisionEnter2D(Collision2D other) {
        if(other.gameObject.tag == "Ground"){
            isOnFloor = true;

            // for jumping animation
            objectAnimator.SetBool("isJumping", false);
        }
    }
}
