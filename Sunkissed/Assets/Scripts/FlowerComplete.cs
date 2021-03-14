using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class FlowerComplete : MonoBehaviour
{
    public int TimeBeforeNextScene;
    public int SceneID;
    private GameManager gameManager;
    // Start is called before the first frame update
    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
    }

    // Update is called once per frame
    void hitByLight()
    {
        print("LEVEL COMPLETE!");

        SceneID = SceneManager.GetActiveScene().buildIndex + 1;
        StartCoroutine(FlowerGrow());
    }

    IEnumerator FlowerGrow()
    {
        yield return new WaitForSeconds(TimeBeforeNextScene);
        int next = SceneID + 1;

        if(next > 5)
        {
            gameManager.StartCoroutine(gameManager.LoadScene(1));
        }
        else
        {
            gameManager.StartCoroutine(gameManager.LoadScene(SceneID));
        }   
    }
}
