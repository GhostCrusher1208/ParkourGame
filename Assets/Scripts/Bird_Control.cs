using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bird_Control : MonoBehaviour
{
    public GameObject Player;
    public GameObject Bird;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == Player)
        {
            Player.transform.parent = Bird.transform;
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
