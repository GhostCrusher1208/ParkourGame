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
            // Zaman yavaþsa normale döndür, deðilse yavaþlat
            if (isTimeSlowed)
            {
                if(!source.isPlaying) { source.PlayOneShot(Fastclip); }
                TargetTimescale = 1f; // Normal hýza dön
                isTimeSlowed = false;  // Yavaþlatma durumunu güncelle
            }
            else if(!isTimeSlowed) 
            {
                if (!source.isPlaying) { 
                source.PlayOneShot(clip);
                                      }// Ses çal
                TargetTimescale = 0.2f;    // Zamaný yavaþlat
                isTimeSlowed = true;       // Yavaþlatma durumunu güncelle
            }

        }
        Debug.Log(isTimeSlowed);
    }
}

