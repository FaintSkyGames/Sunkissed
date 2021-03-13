using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MirrorHandler : MonoBehaviour
{
    int lightDir = 0;
    Transform latestRef;
    RaycastHit2D hit;

    void Update()
    {
        if (lightDir == 1)
        {
            hit = Physics2D.Raycast(transform.position, Vector2.right, Mathf.Infinity);

            Debug.DrawRay(transform.position, Vector2.right, Color.red, 10f);
        }
        if (lightDir == 2)
        {
            hit = Physics2D.Raycast(transform.position, Vector2.left, Mathf.Infinity);

            Debug.DrawRay(transform.position, Vector2.left, Color.red, 10f);
        }
        if (lightDir == 3)
        {
            hit = Physics2D.Raycast(new Vector3(3.87f, 0,0), Vector2.down, Mathf.Infinity);

            Debug.DrawRay(transform.position, Vector2.down, Color.red, 10f);
        }
        if (lightDir == 4)
        {
            hit = Physics2D.Raycast(transform.position, Vector2.up, Mathf.Infinity);

            Debug.DrawRay(transform.position, Vector2.up, Color.red, 10f);
        }
        if (lightDir == 0 && latestRef != null)
        {
            latestRef.SendMessage("noHit");
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


    void hitByLight(string name)
    {
        if(name == "Up")
        {
            lightDir = 1;
        }
        else if (name == "Down")
        {
            lightDir = 2;
        }
        else if (name == "Left")
        {
            lightDir = 3;
        }
        else if (name == "Right")
        {
            lightDir = 4;
        }
    }

    void noHit()
    {
        lightDir = 0;
    }




}
