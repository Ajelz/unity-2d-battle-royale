using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrouchScript : MonoBehaviour
{
    public bool isCrouched = false;
    public CharacterController controller;
    public float crouchDistance = 0.9f;
    public float crouchingSpeed = 0.7f;
    public bool isChangingPosition = false;

    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        //True if Key Pressed and Not changing positions currently
        if (Input.GetKeyDown(KeyCode.LeftShift))
            StartCoroutine(Crouch());
    }

    private IEnumerator Crouch()
    {
        //True if we're already changing position, then end this function
        if (isChangingPosition)
            yield break;

        //Acknowledge that we are changing position so above criteria will keep out multiple calls
        isChangingPosition = true;

        //Get our Starting Height
        float StartingHeight = transform.position.y;

        //Find our End Height
        float EndHeight;
        if (isCrouched)
            EndHeight = StartingHeight + crouchDistance; //We are crouched, hence we are trying to stand up (Go Up / Increase)
        else
            EndHeight = StartingHeight - crouchDistance; //We are standing, hence we are trying to crouch (Go Down / Decrease)

        Debug.Log("E" + EndHeight);

        //Keep changing the Y Value until we reach the end height
        while (transform.position.y != EndHeight)
        {
            //Here we check what action we're doing (Standing/Crouching)
            //Then we move according to the action
            //And finally we check if we have reached the End

            if (isCrouched)
            {
                //We are crouched, hence we are trying to stand up (Go Up / Increase)
                transform.Translate(Vector3.up * crouchingSpeed * Time.deltaTime);

                //True if we reached our goal
                if (transform.position.y >= EndHeight)
                {
                    //Make sure we are EXACTLY at the EndHeight
                    transform.position = new Vector3(transform.position.x, EndHeight, transform.position.z);
                    Debug.Log("COMPLETE!");
                }
            }
            else
            {
                //We are standing, hence we are trying to crouch (Go Down / Decrease)
                transform.Translate(Vector3.down * crouchingSpeed * Time.deltaTime);

                //True if we reached our goal
                if (transform.position.y <= EndHeight)
                {
                    //Make sure we are EXACTLY at the EndHeight
                    transform.position = new Vector3(transform.position.x, EndHeight, transform.position.z);
                    Debug.Log("COMPLETE!");
                }
            }
            yield return null;
        }

        //We have reached the end!

        //Flip the Action as we have succeeded in changing now
        isCrouched = !isCrouched;

        //We're finished changing!
        isChangingPosition = false;

        yield return null;
    }
}
