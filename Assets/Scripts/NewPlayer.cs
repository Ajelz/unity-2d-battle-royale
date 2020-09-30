using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class NewPlayer : MonoBehaviour
{
    // 1. Config - always put config (anything to do with before starting playing)
    [SerializeField] float runSpeed = 8f;
    [SerializeField] float jumpForce = 20f;

    //2. State -  
    bool isOnFloor = false;
    // bool isAlive = true;              /* commenting this because it makes a warning */

    //3. Cache component references
    Rigidbody2D objectRigidbody2D;
    CapsuleCollider2D objectCapsuleCollider2D;
    BoxCollider2D objectBoxCollider2D;
    Animator objectAnimator;
    SpriteRenderer objectSpriteRenderer;

    // Start is called before the first frame update
    void Start()
    {
        objectRigidbody2D = GetComponent<Rigidbody2D>();
        objectCapsuleCollider2D = GetComponent<CapsuleCollider2D>();
        objectBoxCollider2D = GetComponent<BoxCollider2D>();
        objectAnimator = GetComponent<Animator>();
        objectSpriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        move();
        jump();
        animationAndFlip();
    }

    private void move(){
        float controlThrow = CrossPlatformInputManager.GetAxis("Horizontal"); // the value can be from -1 to 1
        objectRigidbody2D.velocity = new Vector2(controlThrow * runSpeed, objectRigidbody2D.velocity.y);
    }

    private void jump(){
        if (CrossPlatformInputManager.GetButtonDown("Jump") && isOnFloor) {
            objectRigidbody2D.velocity += new Vector2(0f, jumpForce);
            isOnFloor = false;
        }
    }

    private void animationAndFlip(){
        if (objectRigidbody2D.velocity.x > 0) {
            objectAnimator.SetBool("running", true);
            objectSpriteRenderer.flipX = false;
        }else if(objectRigidbody2D.velocity.x == 0){
            objectAnimator.SetBool("running", false);
        }else{
            objectAnimator.SetBool("running", true);
            objectSpriteRenderer.flipX = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D other) {
        print(other.gameObject.name);
        if(other.gameObject.name == "Floor"){
            isOnFloor = true;
        }
    }
}
