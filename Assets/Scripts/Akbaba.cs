using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Akbaba : MonoBehaviour
{
    private Rigidbody rb;
    public float speed = 10;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        rb.AddForce(new Vector3(-1,0,0) * Time.deltaTime * speed*100000000,ForceMode.Force);
    }
}
