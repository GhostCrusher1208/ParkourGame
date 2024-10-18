using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mouse_control: MonoBehaviour
{
    public Vector3 moveDirection = new Vector3(0, 0, -1);
    public GameObject Player;
    public GameObject Mouse;
    public float speed = 2f;
    public GameObject colliderr;



    


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == Player)
        {
            Player.transform.parent = Mouse.transform;
            Player.transform.position += speed * moveDirection * Time.deltaTime;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject == Player)
        {
            Player.transform.parent = null;
            
           


        }
    }
}
