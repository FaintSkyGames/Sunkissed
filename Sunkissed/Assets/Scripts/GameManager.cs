using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public Animator SceneTrans;
    public void LoadMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void LoadLevel1()
    {
        StartCoroutine(LoadScene(1));
    }
    public void LoadLevel2()
    {
        StartCoroutine(LoadScene(2));
    }
    public void LoadLevel3()
    {
        StartCoroutine(LoadScene(3));
    }
    public void LoadLevel4()
    {
        StartCoroutine(LoadScene(4));
    }
    public void LoadLevel5()
    {
        StartCoroutine(LoadScene(5));
    }
    public void LoadLevel6()
    {
        StartCoroutine(LoadScene(6));
    }
    public void LoadLevel7()
    {
        StartCoroutine(LoadScene(7));
    }
    public void LoadLevel8()
    {
        StartCoroutine(LoadScene(8));
    }
    public void LoadLevel9()
    {
        StartCoroutine(LoadScene(9));
    }
    public void LoadLevel10()
    {
        StartCoroutine(LoadScene(10));
    }

    public void LoadNextScene()
    {
        int scenenum = SceneManager.GetActiveScene().buildIndex;
        LoadScene(scenenum + 1);
    }

    IEnumerator LoadScene(int value)
    {
        SceneTrans.SetTrigger("NextScene");
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene(value);
    }
    public void Quit()
    {
        Application.Quit();
    }
}
