using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MirrorHandler : MonoBehaviour
{
    int lightDir = 0;
    Transform latestRef;
    RaycastHit2D hit;

    public GameObject up;
    public GameObject down;
    public GameObject left;
    public GameObject right;

    public Collider2D Lup;
    public Collider2D Ldown;
    public Collider2D Lleft;
    public Collider2D Lright;


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

            hit = Physics2D.Raycast(transform.position, Vector2.right, 100f);

            Debug.DrawRay(transform.position, Vector2.right, Color.red, 100f);

            right.SetActive(true);
            up.SetActive(false);
            down.SetActive(false);
            left.SetActive(false);
            if(hit.transform != null)
            if (hit.transform.tag == "Reflection")
            {
                hit.transform.SendMessage("rightLight");
            }

        }
        if (lightDir == 2)
        {
            hit = Physics2D.Raycast(transform.position, Vector2.left, 100f);

            Debug.DrawRay(transform.position, Vector2.left, Color.red, 100f);

            left.SetActive(true);
            up.SetActive(false);
            down.SetActive(false);
            
            right.SetActive(false);

            if (hit.transform != null)
                if (hit.transform.tag == "Reflection")
            {
                hit.transform.SendMessage("leftLight");
            }
        }
        if (lightDir == 3)
        {
            hit = Physics2D.Raycast(transform.position, Vector2.down, 100f);

            Debug.DrawRay(transform.position, Vector2.down, Color.red, 100f);

            down.SetActive(true); 
            up.SetActive(false);
            left.SetActive(false);
            right.SetActive(false);

            if (hit.transform != null)
                if (hit.transform.tag == "Reflection")
            {
                hit.transform.SendMessage("downLight");
            }
        }
        if (lightDir == 4)
        {
            hit = Physics2D.Raycast(transform.position, Vector2.up, 100f);

            Debug.DrawRay(transform.position, Vector2.up, Color.red, 100f);

            up.SetActive(true);
            down.SetActive(false);
            left.SetActive(false);
            right.SetActive(false);

            if (hit.transform != null)
                if (hit.transform.tag == "Reflection")
            {
                hit.transform.SendMessage("upLight");
            }
        }
        if (lightDir == 0)
        {
            up.SetActive(false);
            down.SetActive(false);
            left.SetActive(false);
            right.SetActive(false);
        }




        

        

        lightDir = 0;
    }


   

    void upLight()
    {
        lightDir = 2;
    }
    void downLight()
    {
        lightDir = 1;
    }
    void leftLight()
    {
        lightDir = 4;
    }
    void rightLight()
    {
        lightDir = 3;
    }





}
