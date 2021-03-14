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
        
        SceneID = SceneManager.GetActiveScene().buildIndex;
    }

    // Update is called once per frame
    void hitByLight()
    {
        print("LEVEL COMPLETE!");
<<<<<<< Updated upstream

        SceneID = SceneManager.GetActiveScene().buildIndex + 1;
=======
>>>>>>> Stashed changes
        StartCoroutine(FlowerGrow());
    }

    IEnumerator FlowerGrow()
    {
        yield return new WaitForSeconds(TimeBeforeNextScene);
        int next = SceneID + 1;

        if(next < 6)
        {
            gameManager.StartCoroutine(gameManager.LoadScene(next));
        }
        else
        {
            gameManager.StartCoroutine(gameManager.LoadScene(0));
        }   
    }
}
