using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Glass : MonoBehaviour
{
    public bool inLight;
    public GameObject LightReflection1;
    public GameObject LightReflection2;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Sky"))
        {
            inLight = true;
            LightReflection1.SetActive(true);
            LightReflection2.SetActive(true);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Sky"))
        {
            inLight = false;
            LightReflection1.SetActive(false);
            LightReflection2.SetActive(false);
        }
    }
}
