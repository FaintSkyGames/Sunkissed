using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mirror : MonoBehaviour
{
    public List<GameObject> Reflections;

    public void Reflection(int value)
    {
        if(value == 1)
        {
            Reflections[0].SetActive(true);
        }
        else if (value == 2)
        {
            Reflections[1].SetActive(true);
        }
        else if (value == 3)
        {
            Reflections[2].SetActive(true);
        }
        else if (value == 4)
        {
            Reflections[3].SetActive(true);
        }
        else
        {
            for(int i = 0; i < Reflections.Count; i++)
            {
                Reflections[i].SetActive(false);
            }
        }
    }
}
