using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeSlow : MonoBehaviour
{
    [Header("TimeControllerSetting")]
    public float TargetTimescale=1f;
    public float lerpSpeed = 1f;
    private bool isTimeSlowed = false;

   
    public AudioSource source;
    public AudioClip clip;
    public AudioClip Fastclip;

        

    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        Time.timeScale = Mathf.Lerp(Time.timeScale, TargetTimescale, lerpSpeed * Time.deltaTime);
        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            // Zaman yava�sa normale d�nd�r, de�ilse yava�lat
            if (isTimeSlowed)
            {
                if(!source.isPlaying) { source.PlayOneShot(Fastclip); }
                TargetTimescale = 1f; // Normal h�za d�n
                isTimeSlowed = false;  // Yava�latma durumunu g�ncelle
            }
            else if(!isTimeSlowed) 
            {
                if (!source.isPlaying) { 
                source.PlayOneShot(clip);
                                      }// Ses �al
                TargetTimescale = 0.2f;    // Zaman� yava�lat
                isTimeSlowed = true;       // Yava�latma durumunu g�ncelle
            }

        }
        Debug.Log(isTimeSlowed);
    }
}

