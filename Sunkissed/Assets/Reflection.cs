using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reflection : MonoBehaviour
{
    public bool LightHit;
    public enum SideValue {OneSide, TwoSide, ThreeSide, FourSide };
    public SideValue sideValue;

    public List<BoxCollider2D> Colliders;

    public GameObject Reflect1;
    public GameObject Reflect2;

    private void Start()
    {
        Reflect1.SetActive(false);
        Reflect2.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Reflection"))
        {
            Debug.Log("afasfaf");
            LightHit = true;

            for(int i = 0; i < Colliders.Count; i++)
            {
                Colliders[i].enabled = false;
            }

            var collider = GetComponent<BoxCollider2D>().enabled = true;

            switch (sideValue)
            {
                case SideValue.OneSide:
                    Reflect1.SetActive(true);
                    break;
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Reflection"))
        {
           
            LightHit = false;

           if(LightHit == false)
            {
                for (int i = 0; i < Colliders.Count; i++)
                {
                    Colliders[i].enabled = true;
                }

                switch (sideValue)
                {
                    case SideValue.OneSide:
                        Reflect1.SetActive(false);
                        break;
                }
            }
        }
    }
}
