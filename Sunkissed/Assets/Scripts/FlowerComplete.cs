using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class FlowerComplete : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void hitByLight()
    {

        print("LEVEL COMPLETE!");

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

    }
}
