using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MirrorDetection : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void hitByLight()
    {
        transform.parent.SendMessage("hitByLight", gameObject.name);
    }

    void noHit()
    {
        transform.parent.SendMessage("noHit", gameObject.name);
    }

}
