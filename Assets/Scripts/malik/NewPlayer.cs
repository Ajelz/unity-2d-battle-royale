using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class NewPlayer : MonoBehaviour
{
    // 1. Config - always put config (anything to do with before starting playing)
    [SerializeField] float runSpeed = 20f;
    [SerializeField] float jumpForce = 35f;
    [SerializeField] LayerMask groundLayerMask;
    [SerializeField] Camera cam;
    [SerializeField] Transform weaponPivot;

    //2. State
    Vector2 mousePos;
    Vector2 weaponDirection;

    //3. Cache component references
    Rigidbody2D objectRigidbody2D;
    CapsuleCollider2D objectCapsuleCollider2D;
    Animator objectAnimator;

    // Start is called before the first frame update
    void Start()
    {
        objectRigidbody2D = GetComponent<Rigidbody2D>();
        objectCapsuleCollider2D = GetComponent<CapsuleCollider2D>();
        objectAnimator = GetComponent<Animator>();
        groundLayerMask = LayerMask.GetMask("Ground");
    }

    // Update is called once per frame
    void Update()
    {
        move();
        jump();
        objectAnimation();
        weponToMouse();
    }

    private void move(){
        float controlThrow = CrossPlatformInputManager.GetAxis("Horizontal");
        objectRigidbody2D.velocity = new Vector2(controlThrow * runSpeed, objectRigidbody2D.velocity.y);
    }

    private void jump(){
        if (CrossPlatformInputManager.GetButtonDown("Jump") && isGrounded()) {
            objectRigidbody2D.velocity += new Vector2(0f, jumpForce);
        }
    }

    private void weponToMouse(){
        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
        weaponDirection = mousePos - (Vector2)weaponPivot.position;
        float angle = Mathf.Atan2(weaponDirection.y, weaponDirection.x) * Mathf.Rad2Deg;
        if(mousePos.x < transform.position.x){
            transform.eulerAngles = new Vector3(0, 180, 0);
            weaponPivot.rotation = Quaternion.Euler(180, 0, -angle);
        }else{
            weaponPivot.rotation = Quaternion.Euler(0, 0, angle);
            transform.eulerAngles = new Vector3(0, 0, 0);
        } 
    }

    private void objectAnimation(){
        // for running animation
        if (CrossPlatformInputManager.GetButton("left")) objectAnimator.SetBool("isRunning", true);
        else if (CrossPlatformInputManager.GetButton("right")) objectAnimator.SetBool("isRunning", true);
        else objectAnimator.SetBool("isRunning", false);

        // for jump animation
        if (CrossPlatformInputManager.GetButtonDown("Jump")) objectAnimator.SetBool("isJumping", true);
        else if (!isGrounded()) objectAnimator.SetBool("isJumping", true);
        else if (isGrounded()) objectAnimator.SetBool("isJumping", false);
    }

    private bool isGrounded(){
        RaycastHit2D Hit = Physics2D.Raycast(transform.position, Vector2.down, 3.5f, groundLayerMask);
        return Hit.collider != null;
    }
}
