using Assets.HeroEditor.Common.CharacterScripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 20f;
    public Rigidbody2D rb;
    [SerializeField] CharacterFlip cfp;
    void Start()
    {
        cfp = GetComponent<CharacterFlip>();
    }

    private void Update()
    {
        bool isFacingRight = cfp.Direction();
        if (isFacingRight)
        {
            rb.velocity = transform.right * speed;
        }
        else rb.velocity = (transform.right * -1) * speed;
    }

    private void OnTriggerEnter2D(Collider2D hitInfo)
    {
        Debug.Log(hitInfo.name);
        Destroy(gameObject);
    }
    // Update is called once per frame

}
