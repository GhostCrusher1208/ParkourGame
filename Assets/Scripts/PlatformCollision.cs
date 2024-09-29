using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformCollision : MonoBehaviour
{
    [SerializeField] Transform platform;
    [SerializeField] string playerTag = "Player";

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == playerTag)
        {

            other.gameObject.transform.parent = platform;

        }

    }
    private void OnTriggerExit(Collider other) {

        if (other.gameObject.tag == playerTag)
        {

            other.gameObject.transform.parent = null;

        }

    }
}