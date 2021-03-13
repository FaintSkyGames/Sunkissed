using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectCarry : MonoBehaviour
{
    public GameObject Player;
    public GameObject ToGoObject;
    public GameObject ToGoObject2;
    public bool Pick = true;
    public bool Drop = true;
    private void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
        ToGoObject = GameObject.FindGameObjectWithTag("Object");
        ToGoObject2 = GameObject.FindGameObjectWithTag("Object2");
    }
   
    private void OnTriggerStay2D(Collider2D collision)
    {



        //Pickup Object
        if (Player.GetComponent<PlayerMovement>().Holding == false)
        {
            if (Pick && (Input.GetKey(KeyCode.W)))
            {
                Pick = false;
                Drop = true;
                this.transform.SetParent(ToGoObject.transform);
                Destroy(gameObject.GetComponent<Rigidbody2D>());
                Player.GetComponent<PlayerMovement>().Holding = true;
            }
        }

        ////Dropping Item
        //if (Player.GetComponent<PlayerMovement>().Holding == true)
        //{
        //    Debug.Log("holding is true");
        //    if ((Input.GetKey(KeyCode.S)))
        //    {
        //        Debug.Log("NFHDBFS");
        //        Drop = false;
        //        Pick = true;
        //        this.transform.SetParent(null);
        //        gameObject.AddComponent<Rigidbody2D>();
        //        Rigidbody2D rb = gameObject.GetComponent<Rigidbody2D>();
        //        rb.mass = 100;
        //        Player.GetComponent<PlayerMovement>().Holding = false;
        //    }
        //}

    }


    void Update()
    {

        if ((Input.GetKey(KeyCode.S)))
        {
            if (Player.GetComponent<PlayerMovement>().Holding == true)
        {
            
                Debug.Log("NFHDBFS");
                Drop = false;
                Pick = true;
                this.transform.SetParent(null);
                gameObject.AddComponent<Rigidbody2D>();
                Rigidbody2D rb = gameObject.GetComponent<Rigidbody2D>();
                rb.mass = 100;
                rb.constraints = RigidbodyConstraints2D.FreezeRotation;
                Player.GetComponent<PlayerMovement>().Holding = false;
            }
        }
    }


}
