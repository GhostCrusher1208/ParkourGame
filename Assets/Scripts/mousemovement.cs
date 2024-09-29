using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mousemovement : MonoBehaviour
{
    public Vector3 moveDirection = new Vector3(0, 0, -1);

    public float speed;
    private void Update()
    {
        transform.position += speed* moveDirection * Time.deltaTime;
    }

}
