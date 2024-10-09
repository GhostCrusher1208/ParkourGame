using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class TimeSlow : MonoBehaviour
{
    [Header("TimeControllerSetting")]
    public float TargetTimescale = 1f;
    public float lerpSpeed = 1f;
    private bool isTimeSlowed = false;

    public AudioSource source;
    public AudioClip clip;
    public AudioClip Fastclip;

    public Volume volume;
    private WhiteBalance white; // Class level variable

    // Start is called before the first frame update
    void Start()
    {
        // Get ChannelMixer from Volume Profile and assign it to the class-level variable
        if (volume.profile.TryGet<WhiteBalance>(out white))
        {
            // Modify the initial channel mixer settings
            white.temperature.value = 0f; // Set initial value
        }
        else
        {
            Debug.LogWarning("ChannelMixer not found in the Volume Profile.");
        }
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
                if (!source.isPlaying) { source.PlayOneShot(Fastclip); }
                TargetTimescale = 1f; // Normal hýza dön
                if (white != null) // Check if channelMixer is assigned
                {
                    white.temperature.value = 0f; // Reset channel value
                }
                isTimeSlowed = false;  // Yavaþlatma durumunu güncelle
            }
            else
            {
                if (!source.isPlaying)
                {
                    source.PlayOneShot(clip); // Ses çal
                }
                TargetTimescale = 0.2f;
                if (white != null) // Check if channelMixer is assigned
                {
                    white.temperature.value = -60f; // Set channel value to 50
                }
                // Zamaný yavaþlat
                isTimeSlowed = true;       // Yavaþlatma durumunu güncelle
            }
        }
    }
}
