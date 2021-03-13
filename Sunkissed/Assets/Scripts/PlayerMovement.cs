using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float GroundSpeed = 1.0f;
    public float flyForce = 1.0f;

    public float FlySpeed = 1.0f;

    Rigidbody2D rb;

    bool isGrounded = false;
    public Transform isGroundedChecker;
    public float checkGroundRadius;
    public LayerMask groundLayer;

    bool PickedItem = false;
    public Transform ObjectChecker;
    public LayerMask ObjectLayer;

    public GameObject Sprite;

    public float rememberGroundedFor;
    float lastTimeGrounded;

    public bool Holding = false;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        KeyboardInput();
        FlyingMovement();
        CheckGrounded();
        PlayerRotation();
        //Debug.Log(rb.velocity);
    }

    void KeyboardInput()
    {
        float x = Input.GetAxisRaw("Horizontal");

        //If On Ground
        if (isGrounded == true)
        {
            float moveBy = x * GroundSpeed;
            rb.velocity = new Vector2(moveBy, rb.velocity.y);
        }
        //If Flying.
        else if (isGrounded == false)
        {
            float moveBy = x * FlySpeed;
            rb.velocity = new Vector2(moveBy, rb.velocity.y);
        }
        
    }

    void FlyingMovement()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.velocity = new Vector2(rb.velocity.x, flyForce);
        }
    }

    void CheckGrounded()
    {
        Collider2D colliders = Physics2D.OverlapCircle(isGroundedChecker.position, checkGroundRadius, groundLayer);

        if (colliders != null)
        {
            isGrounded = true;
        }
        else
        {
            if (isGrounded)
            {
                lastTimeGrounded = Time.time;
            }
            isGrounded = false;
        }
    }

    void PlayerRotation()
    {
        if ((rb.velocity[0] > 0.0) && (isGrounded == false))
        {
            Sprite.transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y, -10);
        }
        if ((rb.velocity[0] < 0.0) && (isGrounded == false))
        {
            Sprite.transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y, 10);
        }
        if ((rb.velocity[0] == 0.0) && (isGrounded == false))
        {
            Sprite.transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y, 0);
        }
        if (isGrounded == true)
        {
            Sprite.transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y, 0);
        }
    }
}
