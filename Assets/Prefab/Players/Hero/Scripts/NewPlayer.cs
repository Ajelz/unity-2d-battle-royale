using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewPlayer : MonoBehaviour
{
    // 1. Config - always put config (anything to do with before starting playing)
    [SerializeField] float runSpeed = 20f;
    [SerializeField] float jumpForce = 35f;
    [SerializeField] LayerMask groundLayerMask;

    // for weaponToMouse function
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
        weaponToMouse();
    }

    private void move(){
        float controlThrow = Input.GetAxis("Horizontal");
        objectRigidbody2D.velocity = new Vector2(controlThrow * runSpeed * Time.deltaTime * 50, objectRigidbody2D.velocity.y);
    }

    private void jump(){
        if (Input.GetKeyDown(KeyCode.W) && isGrounded()) {
            objectRigidbody2D.velocity += new Vector2(0f, jumpForce);
        }
    }

    private void weaponToMouse(){
        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
        weaponDirection = mousePos - (Vector2)weaponPivot.position;
        float angle = Mathf.Atan2(weaponDirection.y, weaponDirection.x) * Mathf.Rad2Deg;
        if(mousePos.x < transform.position.x){
            weaponPivot.transform.eulerAngles = new Vector3(180, 0, customClamp(-angle));
            transform.eulerAngles = new Vector3(0, 180, 0);
        }else{
            transform.eulerAngles = new Vector3(0, 0, 0);
            weaponPivot.transform.eulerAngles = new Vector3(0, 0, Mathf.Clamp(angle, -50, 50));
        }
    }

    // this function is for weaponToMouse function
    private float customClamp(float value){
        if(value >= -130 && value <= -90) return -130;
        else if(value <= -130 && value >= -180) return value;
        else if(value <= 180 && value >= 130) return value;
        else if(value <= 130 && value >= 90) return 130;
        return value;
    }

    private void objectAnimation(){
        // for running animation
        if (Input.GetKey(KeyCode.A) && transform.localRotation.eulerAngles.y == 180) {
            objectAnimator.SetBool("isRunning", true);
            objectAnimator.SetBool("isRunningBackwards", false);
        }
        else if (Input.GetKey(KeyCode.D) && transform.localRotation.eulerAngles.y == 0){
            objectAnimator.SetBool("isRunning", true);
            objectAnimator.SetBool("isRunningBackwards", false);
        }
        else if (Input.GetKey(KeyCode.A) && transform.localRotation.eulerAngles.y == 0){
            objectAnimator.SetBool("isRunningBackwards", true);
            objectAnimator.SetBool("isRunning", false);
        }
        else if (Input.GetKey(KeyCode.D) && transform.localRotation.eulerAngles.y == 180){
            objectAnimator.SetBool("isRunningBackwards", true);
            objectAnimator.SetBool("isRunning", false);
        }
        else {
            objectAnimator.SetBool("isRunning", false);
            objectAnimator.SetBool("isRunningBackwards", false);
        }

        // for jump animation
        if (Input.GetKeyDown(KeyCode.W)) objectAnimator.SetBool("isJumping", true);
        else if (!isGrounded()) objectAnimator.SetBool("isJumping", true);
        else if (isGrounded()) objectAnimator.SetBool("isJumping", false);
    }

    private bool isGrounded(){
        RaycastHit2D Hit = Physics2D.Raycast(transform.position, Vector2.down, 3.5f, groundLayerMask);
        return Hit.collider != null;
    }
}
