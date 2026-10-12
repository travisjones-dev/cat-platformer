using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class CatMovement : MonoBehaviour
{

    public float moveSpeed = 3f;

    public float jumpForce;
    private Animator anim;
    private Rigidbody2D rb;
    private Vector2 movement;

    void Start() {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    void Update () {
        movement.x = Input.GetAxisRaw("Horizontal");

        if (movement.x > 0)
        {
            anim.SetInteger("State", 1); // enables the walk right anim
        }
        else if (movement.x < 0)
        {
            anim.SetInteger("State", 2); // enables the walk left anim
        }
        else
        {
            anim.SetInteger("State", 0); // idle anim

        }

        if (Keyboard.current.spaceKey.wasPressedThisFrame)
        {
            Vector2 forceToAdd = new Vector2(0, jumpForce);

            // AddForce adds an actual force to the object
            rb.AddForce(forceToAdd);
        }

    }

        void FixedUpdate()
        {
            rb.linearVelocity = new Vector2(movement.x * moveSpeed, rb.linearVelocity.y);
        }
    
}
