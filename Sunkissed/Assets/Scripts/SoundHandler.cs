using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundHandler : MonoBehaviour
{


    public AudioSource buzz;
    public AudioSource clink;
    public AudioSource grassLand;
    public AudioSource holy;
    public AudioSource ambience;
    public AudioSource beam;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        if(Input.GetKeyDown(KeyCode.Space))
        {
            buzz.Play();
            StartCoroutine(fadeIn(buzz));
        }

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            clink.Play();
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            grassLand.Play();
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            holy.Play();
        }
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            ambience.Play();
        }
        if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            beam.Play();
        }

        if (Input.GetKeyUp(KeyCode.Space))
        {
            StartCoroutine(fadeOut(buzz));
        }

        static IEnumerator fadeIn(AudioSource audioSource)
        {

            print("Start fade");
            float currentTime = 0;
            float start = audioSource.volume;
            float duration = 1;

            while (currentTime < duration)
            {
                currentTime += Time.deltaTime;
                audioSource.volume = Mathf.Lerp(start, 0.2f, currentTime / duration);
                yield return null;
            }
            yield break;
        }


        static IEnumerator fadeOut(AudioSource audioSource)
        {

            print("Start fade");
            float currentTime = 0;
            float start = audioSource.volume;
            float duration = 2;

            while (currentTime < duration)
            {
                currentTime += Time.deltaTime;
                audioSource.volume = Mathf.Lerp(start, 0, currentTime / duration);
                yield return null;
            }
            audioSource.Pause();
            yield break;
        }


    }

    

}
