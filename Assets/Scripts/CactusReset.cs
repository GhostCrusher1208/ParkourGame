using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CactusReset : MonoBehaviour
{
    public Transform player;
    public Transform checkpoint;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name =="Player")
        {
            player.position = checkpoint.position;
        }

    }

}
