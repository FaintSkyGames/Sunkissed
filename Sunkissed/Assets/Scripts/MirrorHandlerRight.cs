using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MirrorHandlerRight : MonoBehaviour
{
    int lightDir = 0;
    Transform latestRef;
    RaycastHit2D hit;

    public GameObject up;
    public GameObject down;
    public GameObject left;
    public GameObject right;
    public LineRenderer line;
    Vector3[] points = new Vector3[2];
    Vector3 nil = new Vector3(0,0);

    public LayerMask skyLayer;

    void Start()
    {
        skyLayer = LayerMask.GetMask("Sky");
    }

    void Update()
    {
        Physics2D.queriesStartInColliders = false;



        //print(lightDir);


        if (hit.transform != null)
        {
            print(hit.transform.name);
        }

        if (lightDir == 1)
        {

            hit = Physics2D.Raycast(transform.position, Vector2.right, 100f, ~skyLayer);

            Debug.DrawRay(transform.position, Vector2.right, Color.red, 100f);

            
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
        if (lightDir == 2)
        {
            hit = Physics2D.Raycast(transform.position, Vector2.left, 100f, ~skyLayer);

            Debug.DrawRay(transform.position, Vector2.left, Color.red, 100f);

           


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
        if (lightDir == 3)
        {
            hit = Physics2D.Raycast(transform.position, Vector2.down, 100f, ~skyLayer);

            Debug.DrawRay(transform.position, Vector2.down, Color.red, 100f);

            

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
        if (lightDir == 4)
        {
            hit = Physics2D.Raycast(transform.position, Vector2.up, 100f, ~skyLayer);

            Debug.DrawRay(transform.position, Vector2.up, Color.red, 100f);

            

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
        


        

        if (lightDir == 0)
        {
            points[0] = nil;
            points[1] = nil;
            line.SetPositions(points);
        }
        else if (hit.transform != null)
        {
            points[0] = nil;
            if (lightDir == 4 || lightDir == 3)
            {
                points[1] = new Vector3(0, hit.transform.position.y - transform.position.y);
            }
            if (lightDir == 1 || lightDir == 2)
            {
                points[1] = new Vector3(hit.transform.position.x - transform.position.x, 0);
            }

            line.SetPositions(points);
        }




        lightDir = 0;
    }




    void upLight()
    {
        lightDir = 1;
    }
    void downLight()
    {
        lightDir = 2;
    }
    void leftLight()
    {
        lightDir = 3;
    }
    void rightLight()
    {
        lightDir = 4;
    }


}
