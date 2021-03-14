using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Glass : MonoBehaviour
{
    public bool inLight;
    public GameObject LightReflection;

    public LayerMask skyLayer;

    public bool Up;
    public bool Down;
    public bool Left;
    public bool Right;
    public LineRenderer line;
    Vector3[] points = new Vector3[2];
    Vector3 nil = new Vector3(0, 0);

    RaycastHit2D hit;

    void Start()
    {
        skyLayer = LayerMask.GetMask("Sky");
    }

    void Update()
    {
        Physics2D.queriesStartInColliders = false;


        if (inLight == true)
        {
            if (Up == true)
            {
                hit = Physics2D.Raycast(transform.position, Vector2.up, Mathf.Infinity, ~skyLayer);

                Debug.DrawRay(transform.position, Vector2.up, Color.red, 10f);

                if (hit.transform != null)
                    if (hit.transform.tag == "Reflection")
                    {
                        hit.transform.SendMessage("upLight");
                    }
                else if (hit.transform.tag == "Flow")
                        {
                        hit.transform.SendMessage("hitByLight");
                    }
            }
            if (Down == true)
            {
                hit = Physics2D.Raycast(transform.position, Vector2.down, Mathf.Infinity, ~skyLayer);

                Debug.DrawRay(transform.position, Vector2.down, Color.red, 10f);

                if (hit.transform != null)
                    if (hit.transform.tag == "Reflection")
                    {
                        hit.transform.SendMessage("downLight");
                    }
                    else if (hit.transform.tag == "Flow")
                    {
                        hit.transform.SendMessage("hitByLight");
                    }
            }
            if (Left == true)
            {
                hit = Physics2D.Raycast(transform.position, Vector2.left, Mathf.Infinity, ~skyLayer);

                Debug.DrawRay(transform.position, Vector2.left, Color.red, 10f);

                if (hit.transform != null)
                    if (hit.transform.tag == "Reflection")
                    {
                        hit.transform.SendMessage("leftLight");
                    }
                    else if (hit.transform.tag == "Flow")
                    {
                        hit.transform.SendMessage("hitByLight");
                    }
            }
            if (Right == true)
            {
                hit = Physics2D.Raycast(transform.position, Vector2.right, Mathf.Infinity, ~skyLayer);

                Debug.DrawRay(transform.position, Vector2.right, Color.red, 10f);

                if (hit.transform != null)
                    if (hit.transform.tag == "Reflection")
                    {
                        hit.transform.SendMessage("rightLight");
                    }
                    else if (hit.transform.tag == "Flow")
                    {
                        hit.transform.SendMessage("hitByLight");
                    }
            }
        }

        if (inLight == false)
        {
            points[0] = nil;
            points[1] = nil;
            line.SetPositions(points);
        }
        else if (hit.transform != null)
        {
            points[0] = nil;
            if (Up == true || Down == true)
            {
                points[1] = new Vector3(0, hit.transform.position.y - transform.position.y);
            }
            if (Left == true || Right == true)
            {
                points[1] = new Vector3(hit.transform.position.x - transform.position.x, 0);
            }

            line.SetPositions(points);
        }
        else if(hit.transform == null)
        {
            points[0] = nil;
            points[1] = nil;
            line.SetPositions(points);
        }


        //if (hit.transform.tag != "Reflection" && latestRef != null)
        //{
        //    latestRef.SendMessage("noHit");
        //}
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Sky"))
        {
            inLight = true;
            print("in light");
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Sky"))
        {
            inLight = false;
            print("not light");
        }
    }
}
