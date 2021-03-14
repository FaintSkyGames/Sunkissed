using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MirrorDetection : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void up()
    {
        transform.parent.SendMessage("up");
    }
    void down()
    {
        transform.parent.SendMessage("down");
    }
    void left()
    {
        transform.parent.SendMessage("left");
    }
    void right()
    {
        transform.parent.SendMessage("right");
    }

    //void noHit()
    //{
    //    transform.parent.SendMessage("noHit", gameObject.name);
    //}

}
