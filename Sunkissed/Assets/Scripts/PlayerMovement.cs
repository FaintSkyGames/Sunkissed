using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float GroundSpeed = 1.0f;
    public float flyForce = 1.0f;

    public float FlySpeed = 1.0f;

    Rigidbody2D rb;

    public bool isGrounded;
    public Transform isGroundedChecker;
    public float checkGroundRadius;
    public LayerMask groundLayer;
    bool buzzPlaying;
    bool PickedItem = false;
    public Transform ObjectChecker;
    public LayerMask ObjectLayer;

    public GameObject Sprite;


    public AudioSource buzz;

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


        if (isGrounded == false)
        {
            if(buzzPlaying == false)
            {
                StartCoroutine(fadeIn(buzz));
                buzzPlaying = true;
            }           
        }


        if (isGrounded == true)
        {
            if (buzzPlaying == true)
            {
                StartCoroutine(fadeOut(buzz));
                buzzPlaying = false;
            }
            
        }
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



    static IEnumerator fadeIn(AudioSource audioSource)
    {

        print("Start fade");
        float currentTime = 0;
        float start = audioSource.volume;
        float duration = 1;
        audioSource.Play();
        while (currentTime < duration)
        {
            currentTime += Time.deltaTime;
            audioSource.volume = Mathf.Lerp(start, 0.2f, currentTime / duration);
            yield return null;
        }
        
        yield break;
    }


    static IEnumerator fadeOut(AudioSource audioSource)
    {

        print("Start fade");
        float currentTime = 0;
        float start = audioSource.volume;
        float duration = 2;

        while (currentTime < duration)
        {
            currentTime += Time.deltaTime;
            audioSource.volume = Mathf.Lerp(start, 0, currentTime / duration);
            yield return null;
        }
        audioSource.Pause();
        yield break;
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
