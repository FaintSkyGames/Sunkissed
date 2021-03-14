using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public float MoveTime = 100f;
    public GameObject Location;

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.Lerp(transform.position, Location.transform.position, Time.deltaTime * MoveTime);
    }
}
