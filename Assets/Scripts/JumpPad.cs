using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpPad : MonoBehaviour
{
    [SerializeField] float JumpPower;
    private Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    private void OnCollisionEnter(Collision other)
    {
        
           if (other.gameObject.CompareTag("Player"))
           {
                rb= other.gameObject.GetComponent<Rigidbody>();
                rb.AddForce(Vector3.up*JumpPower,ForceMode.Impulse);
           }
        
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
