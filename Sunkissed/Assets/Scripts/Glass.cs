using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Glass : MonoBehaviour
{
    public bool inLight;
    public GameObject LightReflection;

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
