using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DisplaySpeed : MonoBehaviour
{
    public  Rigidbody rb;
    public TextMeshProUGUI speedtext;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float speed = rb.velocity.magnitude;

        speedtext.text = "Speed:" + speed.ToString("F2");
    }
}
