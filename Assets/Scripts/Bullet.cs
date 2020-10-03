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
        rb.velocity = transform.right.normalized * speed;
    }

    private void OnTriggerEnter2D(Collider2D hitInfo)
    {
        Debug.Log(hitInfo.name);
        Destroy(gameObject);
    }
    // Update is called once per frame

}
