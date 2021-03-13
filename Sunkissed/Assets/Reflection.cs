using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reflection : MonoBehaviour
{
    public bool LightHit;
    public enum SideValue {Left, Right, Up, Down };
    public SideValue sideValue;
    private int SideNumber;

    private void Start()
    {
        switch (sideValue)
        {
            case SideValue.Up:
                SideNumber = 1;
                break;
            case SideValue.Left:
                SideNumber = 2;
                break;
            case SideValue.Down:
                SideNumber = 3;
                break;
            case SideValue.Right:
                SideNumber = 4;
                break;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Reflection"))
        {
            LightHit = true;
            var mirror = GetComponentInParent<Mirror>();
            mirror.Reflection(SideNumber);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Reflection"))
        {
            LightHit = false;
            var mirror = GetComponentInParent<Mirror>();
            mirror.Reflection(0);
        }
    }
}
