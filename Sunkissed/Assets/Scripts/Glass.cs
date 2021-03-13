using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Glass : MonoBehaviour
{
    public bool inLight;
    public GameObject LightReflection;
    Transform latestRef;

    public bool Up;
    public bool Down;
    public bool Left;
    public bool Right;


    RaycastHit2D hit;

    void Update()
    {
        

        if (Up == true)
        {
            hit = Physics2D.Raycast(transform.position, Vector2.up, Mathf.Infinity);

            Debug.DrawRay(transform.position, Vector2.up, Color.red, 10f);
        }
        if (Down == true)
        {
            hit = Physics2D.Raycast(transform.position, Vector2.down, Mathf.Infinity);

            Debug.DrawRay(transform.position, Vector2.down, Color.red, 10f);
        }
        if (Left == true)
        {
            hit = Physics2D.Raycast(transform.position, Vector2.left, Mathf.Infinity);

            Debug.DrawRay(transform.position, Vector2.left, Color.red, 10f);
        }
        if (Right == true)
        {
            hit = Physics2D.Raycast(transform.position, Vector2.right, Mathf.Infinity);

            Debug.DrawRay(transform.position, Vector2.right, Color.red, 10f);
        }


        if (hit.transform.tag == "Reflection")
        {
            latestRef = hit.transform;
            hit.transform.SendMessage("hitByLight");
        }

        if (hit.transform.tag != "Reflection" && latestRef != null)
        {
            latestRef.SendMessage("noHit");
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Sky"))
        {
            inLight = true;
            LightReflection.SetActive(true);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Sky"))
        {
            inLight = false;
            LightReflection.SetActive(false);
        }
    }
}
