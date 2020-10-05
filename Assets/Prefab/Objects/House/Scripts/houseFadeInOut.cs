using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class houseFadeInOut : MonoBehaviour
{

    // 1. Config

    //2. State

    //3. Cache component references
    Animator objectAnimator;

    // Start is called before the first frame update
    void Start()
    {
        objectAnimator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other) {
        objectAnimator.SetBool("isInHouse", true);
    }

    private void OnTriggerExit2D(Collider2D other) {
        objectAnimator.SetBool("isInHouse", false);
    }
}
