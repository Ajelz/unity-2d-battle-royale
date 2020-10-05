using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationControl : MonoBehaviour
{   
    [SerializeField] LayerMask groundLayerMask;
    Animator objectAnimator;
    
    // Start is called before the first frame update
    void Start()
    {
        objectAnimator = GetComponent<Animator>();
        groundLayerMask = LayerMask.GetMask("Ground");
    }

    // Update is called once per frame
    void Update()
    {
        objectAnimation();
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
